    if (control.ToolTip != null)
    {
        // Main condition
        if (control.ToolTip is ToolTip)
        {
            var castToolTip = (ToolTip)control.ToolTip;
            castToolTip.IsOpen = true;
        }
        else
        {
            toolTip.Content = control.ToolTip;
            toolTip.StaysOpen = false;
            toolTip.IsOpen = true;
        }
    }  
