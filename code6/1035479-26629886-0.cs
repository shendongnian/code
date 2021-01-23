    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        //e.Handled = true;
        e.Handled = Validate(textBox1.Text, e);
    }
    private static bool Validate(string p, KeyPressEventArgs e)
    {
        bool valid = false;
        try
        {
            if (System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == e.KeyChar.ToString())
            {
                // e.Handled = true;
                valid = false;
            }
            else
            {
                string t = string.Format("{0}{1}", p, (e.KeyChar));
                if (!(Regex.IsMatch(t, @"^\d{1,3}(\.\d{0,3})?$") && !string.IsNullOrEmpty(t)))
                {
                    valid = true;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return valid;
    }
