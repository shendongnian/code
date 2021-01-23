    private void button1_Click(object sender, EventArgs e)
        {
            sum = x + y;
            MessageBox.Show("Ans=" + sum);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string myString = sum.ToString();
            textBox3.Text = myString;
        }
