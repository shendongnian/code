    public void PreventInput(Telerik.WinControls.UI.RadTextBox tb, 
        KeyPressEventArgs e, bool isDouble = true)
    {
        string input = tb.Text ?? string.Empty;
        if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
        {
            return;
        }
        if (isDouble && e.KeyChar == '.' && !input.Contains("."))
        {
            return;
        }
        e.Handled = true;
    }
