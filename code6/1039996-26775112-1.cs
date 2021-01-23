     private void textBox1_TextChanged(object sender, EventArgs e)
            {
                calculate();
            }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }
        private void calculate()
        {
            double a = 0, b = 0, demo;
            if (double.TryParse(textBox1.Text, out demo))
                a = double.Parse(textBox1.Text); //textbox 1
            if (double.TryParse(textBox2.Text, out demo))
                b = double.Parse(textBox2.Text); //textbox 2
            double s = a * b;
            textBox3.Text = s.ToString(); //s is the result
        }
