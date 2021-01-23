    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Space)
        {
            if (CultureInfo.CurrentUICulture == CultureInfo.CreateSpecificCulture("bo-CN")
            {
                richTextBox1.AppendText(" ་ ");
                e.Handled = true;
            }
        }
    }
