        private void button1_Click(object sender, EventArgs e)
        {
            decimal d1, d2 = 0;
            bool isFirstNumber = Decimal.TryParse(textBox1.Text, out d1);
            bool isSecondNumber = Decimal.TryParse(textBox2.Text, out d2);
            if (isFirstNumber && isSecondNumber)
            {
                textBoxAns.Text = (d1 + d2).ToString();
            }
            else
            {
                MessageBox.Show("Please enter a number", "Error");
            }
        }
