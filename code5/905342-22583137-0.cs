        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Multiply();
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Multiply();
        }
        public void Multiply()
        {
            float a, b;
            bool isAValid = float.TryParse(textBox8.Text, out a);
            bool isBValid = float.TryParse(textBox10.Text, out b);
            if (isAValid && isBValid)
                textBox7.Text = (a * b).ToString();
            else
                textBox7.Text = "Invalid input";
        }
