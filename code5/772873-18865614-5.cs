    public void setAllTextBoxs(Control control)
    {
        control.Controls.OfType<TextBox>().ToList().ForEach(c => c.BorderStyle = BorderStyle.FixedSingle);
        control.Controls.Cast<Control>().Where(c => c.GetType() != typeof(TextBox) && c.HasChildren).ToList().ForEach(c => setAllTextBoxs(c));
    }
