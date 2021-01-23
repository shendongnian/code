    private void HideControls<TControl>(Control parentControl)
        where TControl : Control
    {
        var controls = parentControl.Controls.OfType<TControl>();
        foreach (var control in controls)
        {
            control.Visible = false;
        }
    }
