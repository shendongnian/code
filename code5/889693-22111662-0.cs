    public void clearTextBox(Control control)
    {
        foreach (Control ctl in control.Controls)
        {
            if (ctl is TextBox)
            {
                TextBox textBox = ctl as TextBox;
                if (textBox.Text == "&nbsp;")
                { textBox.Text = ""; }
            }
        }
    }
