    private void SetAllLabelsWithCssClassValueToInvisible(Control parentControl, 
                                                          string className)
    {
        foreach(Control childControl in parentControls.Controls)
        {
            // Try to cast control to a label, null if it fails
            var label = childControl as Label;
         
            // Check to see if we successfully cast to label or not
            if(label != null)
            {
                // Yes, it is a label 
                // Does it have the correct CssClass property value?
                if(label.CssClass == className)
                {
                    // Update the Visible property to false
                    label.Visible = false;
                }
            }
        }
    }
