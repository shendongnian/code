    private void checkControl(Control control)
    {
        foreach (Control c in control.Controls)
        {
            var textBox = c as TextBox;
            if (textBox != null)
                textBox.BorderStyle = BorderStyle.FixedSingle;
            else
                checkControl(c);
        }
    }
