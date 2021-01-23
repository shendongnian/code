    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
                {
                    if (Regex.IsMatch(
                     textBox1.Text,
                     "^\\d*\\.\\d{1}$")) e.Handled = true;
                }
                else e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
