    namespace Calculator
    {
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }
 
        private string displayString;
        private decimal displayValue;
    
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
                            calc.Add ( calc.Operand_1, cal.Operand_2 )
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
