using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_New_Assignment_3
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        //mmmmmmm        Clear Method         mmmmmmm  
        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public void clearMethod()
        {
            stereoSystemCheckBox.Checked = false;
            leatherInteriorCheckBox.Checked = false;
            gpsCheckBox.Checked = false;
            standardRadioButton.Checked = false;
            if (standardRadioButton.Checked) standardRadioButton.Checked = false;
            else if (modifiedRadioButton.Checked) modifiedRadioButton.Checked = false;
            else if (customizedRadioButton.Checked) customizedRadioButton.Checked = false;


            //add other false

        } //end of Method Clear

        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        //mmmmmmm      Set Standard values    mmmmmmm  
        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public void setStdValues()
        {
            basicPriceTextBox.Text = "0";
            tradeInTextBox.Text = "0";
            access1Textbox.Text = "30.50";
            access2Textbox.Text = "530.99";
            access3Textbox.Text = "301.99";
            standardTextBox.Text = "0";
            modifiedTextBox.Text = "370.50";
            customTextBox.Text = "1257.99";
            VATTextBox.Text = "6";
        } //end of Method Set Standard values 

        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        //mmmmmmm     Basic Price  Method     mmmmmmm  
        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public double basicPrice()
        {
            double basicPriceVar = 0;
            if (!Double.TryParse(basicPriceTextBox.Text, out basicPriceVar))
                return 0;

            return basicPriceVar; // input for basic price 
        } //end of Method Basic Price

        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        //mmmmmm    Trade In Price  Method    mmmmmmm  
        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm  
        public double tradeInPrice()
        {



            return double.Parse(tradeInTextBox.Text); // input for trade in allowanc    
        } //end of Method Trade In Price

        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        //mmmmm  Checkbox Method     mmmmmmm
        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm 
        public double Chkbox()
        {
            double Chkbox_1 = 0; double Chkbox_2 = 0; double Chkbox_3 = 0;

            Chkbox_1 = stereoSystemCheckBox.Checked ? Chkbox_1 = double.Parse(access1Textbox.Text) : Chkbox_1; // Ternary
            Chkbox_2 = leatherInteriorCheckBox.Checked ? Chkbox_2 = double.Parse(access2Textbox.Text) : Chkbox_2; // // Ternary
            Chkbox_3 = gpsCheckBox.Checked ? Chkbox_3 = double.Parse(access3Textbox.Text) : Chkbox_3; // // Ternary
            return Chkbox_1 + Chkbox_2 + Chkbox_3;
        } //end of Method Checkbox Method

        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        //mmmmm Radio Buttons Method mmmmmmm
        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm 
        public double radioButtons()
        {
            if (modifiedRadioButton.Checked) return double.Parse(modifiedTextBox.Text); // input for basic price            
            else if (customizedRadioButton.Checked) return double.Parse(customTextBox.Text); // input for basic price            
            else return 0;
        } //end of Method Radio Buttons

        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        //mmmmmm         VAT  Method          mmmmmmm  
        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm  
        public double vatMethod()
        { // add trim
            return double.Parse(VATTextBox.Text);
        } //end of VAT  Method   

        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        //mmmmmm      Display Total Method    mmmmmmm  
        //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm  
        public void dsply_total(double total)
        {
            resultLabel.Text = total.ToString();
        } //end of Method Trade Display Total                                


        //bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
        //bbbbbbb   Calculate Button Press    bbbbbbb  
        //bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
        protected void purchaseButton_Click(object sender, EventArgs e)
        {


            resultLabel.Text = ""; // clear resultLabel
            double total = 0.0; // setup datatype double called "total"  
            double basicPriceVar;// setup variable basicPriceVar
            double tradeInPriceVar;// setup variable tradeInPriceVar
            double chkBoxTotalVar;// setup variable chkBoxTotalVar
            double radioButtonsVar; // setup variable radioButtonsVar    
            double VAT; // setup variabl VAT 

            String Password = PassTextBox.Text;

            if (Password != "Password1234")
            { // if Password not entered reset default 
                setStdValues();
            }

            basicPriceVar = basicPrice();// basicPriceVar = Method Basic Price
            tradeInPriceVar = tradeInPrice(); // tradeInPriceVar = subtract Trade In Price
            chkBoxTotalVar = Chkbox();// chkBoxTotalVar = add Checkbox total            
            radioButtonsVar = radioButtons(); // radioButtonsVar = add radio buttons total
            VAT = vatMethod();
            VAT = VAT / 100;

            total = (basicPriceVar - tradeInPriceVar);
            total = total + (radioButtonsVar + chkBoxTotalVar);
            //   total = total + (total * VAT); // add VAT to the total

            dsply_total(total);// total display total with Method
        }// END Button

        //bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
        //bbbbbbb     Reset Button Press      bbbbbbb  
        //bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
        protected void resetButton_Click(object sender, EventArgs e)
        {
            setStdValues();
        }// END Button

        //bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
        //bbbbbbb     Clear Button Press      bbbbbbb  
        //bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
        protected void clearButton_Click(object sender, EventArgs e)
        {
            clearMethod();
        }// END Button








    }
}