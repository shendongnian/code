    private void button1_Click(object sender, EventArgs e)
    {
        double result;
        int x, y;
        x = Convert.ToInt16(textBox1.Text);
        y = Convert.ToInt16(textBox2.Text);
        if (radioButton1.Checked)
            result = Math.Pow(x,y);
        if (radioButton2.Checked)
           result = (x / y);
        //...
    }
