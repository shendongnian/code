    /// <summary>Setting a toolTip on a custom control unfortunately doesn't set it on child
    /// controls within its drawing area. This is a workaround for that.</summary>
    private void PropagateToolTips(Control parent = null)
    {
        parent = parent ?? this;
        string toolTip = toolTip1.GetToolTip(parent);
        if (toolTip == "")
            toolTip = null;
        foreach (Control child in parent.Controls)
        {
            // If the parent has a toolTip, and the child control does not
            // have its own toolTip set - set it to match the parent toolTip.
            if (toolTip != null && String.IsNullOrEmpty(toolTip1.GetToolTip(child)))
                toolTip1.SetToolTip(child, toolTip);
            // Recurse on the child control
            PropagateToolTips(child);
        }
    }
