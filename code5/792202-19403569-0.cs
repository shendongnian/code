    protected void Page_PreRender(Object sender, EventArgs e)
    {
        var allTextControlsWithTooltips = new List<WebControl>();
        var stack = new Stack<Control>(this.Controls.Cast<Control>());
        while (stack.Count > 0)
        {
            Control currentControl = stack.Pop();
            if (currentControl is WebControl && currentControl is ITextControl)
                allTextControlsWithTooltips.Add((WebControl)currentControl);
            foreach (Control control in currentControl.Controls)
                stack.Push(control);
        }
        foreach (var txt in allTextControlsWithTooltips)
            txt.ToolTip = ((ITextControl)txt).Text;
    }
