    foreach (Control c in EnumerateControlsRecursive(Page))
    {
        if(c is TextBox)
        {
            var theTextBox = c as TextBox;
            theTextBox.Visible = false;
        }
        if(c is Label)
        {
            var theLabel = c as Label;
            theLabel.Visible = false;
        }
        ...
    }
