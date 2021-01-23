     private void button1_Click(object sender, EventArgs e)
     {
            double itemValue = Double.Parse(textBox1.Text);
            double Keys = itemValue * 0.8 / 2.15;
    
            label2.Text = "Value of item in keys:" + Keys;
    }
