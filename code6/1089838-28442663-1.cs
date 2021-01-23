    foreach (Control c in EnumerateControlsRecursive(Page))
        {
            if (c is DropDownList)
            {
                ControlList.Add(c);
            }
        }
        foreach(DropDownList d in ControlList)
        {
            if(d.SelectedValue == "0")
            {
                HandleError(d.ID + " must have a value.");
            }
        }
