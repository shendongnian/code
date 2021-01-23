        private void button1_Click(object sender, EventArgs e)
        {
            double dbl;
            if (double.TryParse(textBox1.Text, out dbl))
            {
                // ... do something with "dbl" in here ...
            }
            else
            {
                MessageBox.Show(textBox1.Text, "Please enter a valid double!");
            }
        }
