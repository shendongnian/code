        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            countChar = this.textBox1.Text;
            if (String.IsNullOrEmpty(this.textBox1.Text))
            {
                e.Handled = (char.IsLetter(e.KeyChar);
            }
            else if (countChar.Length == 1 || countChar.Length == 2)
            {
                e.Handled = e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8;
            }
           e.Handled=false;
       }
