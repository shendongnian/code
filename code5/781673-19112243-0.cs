    Control c = FindControl(lbl1.AssociatedControlID);
    if(c == null) // Not found
    else
    {
        Type t = c.GetType(); // Gets the type of the control
        if(c is TextBox) // I'm a textbox
        else if(c is DropDownList) // I'm a DropdownList
    }
