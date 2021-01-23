    private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
            {
                 if (!System.Text.RegularExpressions.Regex.IsMatch(textBox28.Text, "[^0-9^+.]") && textBox28.Text[0]==".")
                             e.Handled = true;
            }
