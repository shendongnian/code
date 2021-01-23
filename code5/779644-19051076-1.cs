    double num1, num2, result;
    string operation;
    private void button14_Click(object sender, EventArgs e) //Minus Button
    {
        if (textBox1.Text != String.Empty) //Added if statement to see if the textBox is empty
            num1 = Convert.ToDouble(textBox1.Text);
        else
            num1 = 0; //If textBox is empty, set num1 to 0
        textBox1.Text = String.Empty;
        operation = "-";
    }
    private void button13_Click(object sender, EventArgs e) //Equals Button
    {
        if (textBox1.Text != String.Empty)
            num2 = Convert.ToDouble(textBox1.Text);
        else
            num2 = 0;
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
