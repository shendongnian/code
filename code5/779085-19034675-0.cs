    public static void TrimTextBoxesRecursive(Control root)
    {
        foreach (Control control in root.Controls)
        {
            if (control is TextBox)
            {
                var textbox = control as TextBox;
                textbox.Text = textbox.Text.Trim();
            }
            else
            {
                TrimTextBoxesRecursive(control);
            }
        }
    }
