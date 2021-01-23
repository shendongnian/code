    double num1, num2, result;
    string operation;
    private void button14_Click(object sender, EventArgs e) //Minus Button
    {
        num1 = Convert.ToDouble(textBox1.Text);
        textBox1.Text = String.Empty;
        operation = "-";
    }
    private void button13_Click(object sender, EventArgs e) //Equals Button
    {
        num2 = Convert.ToDouble(textBox1.Text);
        if (operation == "-")
        {
            result = num1 - num2;
            textBox1.Text = Convert.ToString(result);
        }
        if (operation == "+")
        {
            //You got it
        }
        //And so on...
    }
