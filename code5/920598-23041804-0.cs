    var control = sender as Control;
    if (control.ToolTip != null)
    {
        if (control.ToolTip is ToolTip)
        {
            var toolTip = (ToolTip)control.ToolTip;
            toolTip.IsOpen = value;
        }
        else
        {
            toolTip.Content = control.ToolTip;
            toolTip.IsOpen = value;
        }
    }  
