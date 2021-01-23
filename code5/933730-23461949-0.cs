    IEnumerable<Control> controls = this.Controls
        .Cast<Control>()
        .Where(c => c is RadioButton || c is CheckBox || (c is TextBox && c.Name == "txtFoo"));
    foreach (Control control in controls)
    {
        if (control is CheckBox)
            // Do checkbox stuff
        else if (control is RadioButton)
            // DO radiobutton stuff
        else if (control is TextBox)
            // Do textbox stuff
    }
