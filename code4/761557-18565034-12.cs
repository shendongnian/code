    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string op;
        private string num1;
        private string num2;
        private void handleNumberButtonClick(object sender, System.EventArgs e)
        {
            var num = Convert.ToInt16(((Button)sender).Tag);
            if (op == null)
                num1 += num;
            else
                num2 += num;
            PrintEquation(num1, op, num2);
        }
        private void PrintEquation(string first, string oper = null, string second = null, string equals = null, string result = null)
        {
            txtBox.Text = first + oper + second + equals + result;
        }
        private void handleOperatorButtonClick(object sender, System.EventArgs e)
        {
            op = ((Button)sender).Tag.ToString();
            PrintEquation(num1, op);
        }
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (op == null && !num1.Contains(".")) num1 += ".";
            if (op != null && !num2.Contains(".")) num2 += ".";
            this.PrintEquation(num1, op, num2);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBox.Clear();
            op = null;
            num1 = null;
            num2 = null;
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            double result = 0;
            var first = Convert.ToDouble(num1);
            var second = Convert.ToDouble(num2);
            switch (op)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "/":
                    if (second != 0)
                    {
                        result = first / second;
                    }
                    else
                    {
                        errorLbl.Text = "You can't divide by zero... sign up for Math 100 please =)";
                    }
                    break;
                case "*":
                    result = first * second;
                    break;
            }
            this.PrintEquation(num1, op, num2, "=", result.ToString());
        }
    }
