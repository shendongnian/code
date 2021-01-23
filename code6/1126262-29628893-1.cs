    private void CheckInput(object sender, KeyPressEventArgs e)
    {
        // Make sure only digits, . and + 
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+')
        {
            e.Handled = true;
        }
        // Make sure . is in correct places only
        else if (e.KeyChar == '.')
        {
            for (int i = textBox1.SelectionStart - 1; i >= 0; i--)
            {
                if (textBox1.Text[i] == '.')
                {                       
                    e.Handled = true;
                    break;
                }
                else if (textBox1.Text[i] == '+') break;
            }
        }
        // Make sure character before + is a digit
        else if (e.KeyChar == '+' 
            && !char.IsDigit(textBox1.Text[textBox1.SelectionStart - 1]))
        {
            e.Handled = true;
        }
    }
