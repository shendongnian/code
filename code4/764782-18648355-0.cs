         private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int valueCheck = 0;
            if (textBox1.TextLength >= 1)
            {
                Int32.TryParse(textBox1.Text, out valueCheck);
            }
            if (valueCheck < 1)
            {
                textBox1.ForeColor = Color.Red;
            }
            else if (valueCheck > 0)
            {
                textBox1.ForeColor = Color.Black;
            }
            valueCheck = 0;
        }
