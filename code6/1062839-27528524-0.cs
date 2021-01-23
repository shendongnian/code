    protected void HideTextBoxes(Control ctrl)
    {
        foreach (var c in ctrl.Controls)
        {
            if (c is TextBox && ((TextBox)c).Text == String.Empty)
            {
                ((TextBox)c).Visible = false;
            }
    
        }
    
    
    }
