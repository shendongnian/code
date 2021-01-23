    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Calculator
    {
    public class Calculator
    {
    
        public Decimal displayValue;
        public Decimal currentValue;
        public Decimal Operand_1;
        public Decimal Operand_2;
        private bool Operand_1_Added = false;
        private bool Operand_2_Added = false;
          
         public void AddOperand(Decimal Operand)
        {
                if(Operand_1_Added) 
                    {
                      Operand_2 = Operand;
                      Operand_2_Added = true;
                    }
                else {
                      Operand_1 = Operand;
                      Operand_1_Added = true;
                     }
         }
         public void Add(Decimal Arg1, Decimal Arg2)
        {
    
            currentValue = Arg1 + Arg2;
    
        }
    
         public void Reciprocal(Decimal Arg)
     {
         currentValue = 1 / Arg;
     }
    
         public void Clear()
         {
             currentValue = 0;
             displayValue = 0;
             Operand_1 = 0;
             0perand_2 = 0;
         }
    
         public decimal CurrentValue
         {
           get
              {
               return currentValue;
              }
    
         }
    }
    namespace Calculator
    {
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }
    
        // The following fields are used to store the value that's currently
        // displayed by the calculator. displayString is a string value that's
        // constructed as the user clicks numeric keys and the decimal and +/-
        // key. The Convert.ToDecimal method is then used to convert this to a decimal
        // field that's stored in displayValue.
        private string displayString;
        private decimal displayValue;
    
        // The following bool fields are used to control numeric entry.
        // newValue indicates whether the calculator is ready to receive a
        // new numeric value. Once the user clicks a digit button, newValue is
        // set to false. When the user clicks a button that "enters" the value, 
        // such as Add or Equals, newValue is set to true so the user can enter 
        // another value.
        // decimalEntered is used to restrict the entry to a single decimal point.
        // It is set to true whenever newValue is set to true, and it is set to 
        // false whenever the user clicks the decimal point button.
        private bool newValue;
        private bool decimalEntered;
    
        private Calculator calc = new Calculator();
        private String Operation = "";
    
        private void Form1_Load(object sender, System.EventArgs e)
        {
            displayValue = 0;
            displayString = displayValue.ToString();
            newValue = true;
            decimalEntered = false;
        }
    
        // This method handles the 0 through 9 keys, appending the digit clicked
        // to the displayString field. 
        private void btnNumber_Click(object sender, System.EventArgs e)
        {
            if (newValue)
            {
                displayString = "";
                newValue = false;
            }
            displayString += ((Button)sender).Tag.ToString();
            displayValue = Convert.ToDecimal(displayString);
            calc.AddOperand(displayValue);
            txtDisplay.Text = displayValue.ToString();
        }
    
        // This method removes the last character from the displayString field.
        private void btnBackSpace_Click(object sender, System.EventArgs e)
        {
            if (displayString.Length > 1)
            {
                displayString = displayString.Substring(0, displayString.Length - 1);
                displayValue = Convert.ToDecimal(displayString);
                txtDisplay.Text = displayValue.ToString();
            }
            else
            {
                displayString = "";
                displayValue = 0;
                txtDisplay.Text = displayValue.ToString();
            }
    
        }
    
        private void btnClear_Click(object sender, System.EventArgs e)
        {
            calc.Clear();
            displayString = "";
            displayValue = 0;
            txtDisplay.Text = displayValue.ToString();
            newValue = true;
            decimalEntered = false;
        }
    
        // This method appends a decimal point to the displayString field if the
        // user has not already entered a decimal point.
        private void btnDecimal_Click(object sender, System.EventArgs e)
        {
            if (newValue)
            {
                displayString = "0";
                newValue = false;
            }
            if (!decimalEntered)
            {
                displayString += ".";
                displayValue = Convert.ToDecimal(displayString);
                txtDisplay.Text = displayValue.ToString();
                decimalEntered = true;
            }
        }
    
        private void btnSign_Click(object sender, System.EventArgs e)
        {
            displayValue = -displayValue;
            txtDisplay.Text = displayValue.ToString();
        }
    
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            //Specify Operation
            Operation = "Addition";
        }
        
        private void btnReciprocal_Click(object sender, System.EventArgs e)
        {
                Operation = "Reciprocal"
        }
    
        private void btnEquals_Click(object sender, System.EventArgs e)
        {
            try
            {
              switch(Operation){
                case "Addition":
                            calc.Add ( calc.0perand_1, cal.Operand_2 )
                            break;
                case "Reciprocal"
                            calc.Reciprocal( calc.Operand1);
                            break;
                default: break;
               }
               displayValue = calc.CurrentValue;
               
            }    
            //Catch All your Exceptions
 
            catch (DivideByZeroException)
            {
                displayValue = 0;
                txtDisplay.Text = "Cannot divide by zero.";
                newValue = true;
                decimalEntered = false;
            }
        }
    
    }
