    if (control.ToolTip != null)
    {
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
