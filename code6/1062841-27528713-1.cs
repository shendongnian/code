    protected void HideTextBoxes(Control ctrl)
    {
        //Iterate over controlls
        foreach (var c in ctrl.Controls)
        {
            //Check for Textbox controls with the .Text property equal to Null or Empty.
            if (c is TextBox && string.IsNullOrEmpty(((TextBox)c).Text))
            {
                //Set visibility of Textbox control to invisible.
                ((TextBox)c).Visible = false;
            }
        }
    }
