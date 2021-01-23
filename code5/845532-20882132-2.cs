    namespace WindowsFormsApplication
    {
        public partial class Form1 : Form
        {
            private Calculator calculator;
    
            public Form1()
            {
                InitializeComponent();
                calculator = new Calculator();
            }
    
            private void btnMultiply_Click(object sender, EventArgs e)
            {
                double multiplyScore = calculator.Multiply(Convert.ToDouble(tBoxValue1.Text), Convert.ToDouble(tBoxValue2.Text));
            }
        }
    }
