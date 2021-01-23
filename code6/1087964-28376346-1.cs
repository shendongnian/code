        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int num1 = Int32.Parse(textBox1.Text), num2 = Int32.Parse(textBox2.Text);
                textBox3.Text = (num1 - num2).ToString();
            }
            catch { }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1_TextChanged(sender, e);
        }
