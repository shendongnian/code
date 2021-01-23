    public void setAllTextBoxs(Control control)
    {
        foreach (Control c in control.Controls)
            if (c is TextBox)
                (c as TextBox).BorderStyle = BorderStyle.FixedSingle;
            else if(c.HasChildren)
                setAllTextBoxs(c);
    }
