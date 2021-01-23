        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            countChar = this.textBox1.Text;
            if (String.IsNullOrEmpty(this.textBox1.Text))
            {
                e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            }
            else if (countChar.Length == 1 || countChar.Length == 2)
            {
                e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            }
            else if (countChar.Length == 3)
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
            else
            {
                e.Handled = true;
            }
        }
