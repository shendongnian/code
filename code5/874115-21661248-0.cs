    bool txt1Numeric = Information.IsNumeric(textBox1.Text);
    bool txt2Numeric = Information.IsNumeric(textBox2.Text);
    if (txt1Numeric && txt2Numeric)
    {
        decimal val1 = Convert.ToDecimal(textBox1.Text);
        decimal val2 = Convert.ToDecimal(textBox2.Text);
        textBoxAns.Text = (val1 + val2).ToString();
    }
    else
    {
        MessageBox.Show("Please enter a number", "Error");
    }
