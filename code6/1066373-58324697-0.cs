    private void SetupNestedClickEvents(Control control, EventHandler handler)
    {
        control.Click += handler;
        foreach (Control ctl in control.Controls)
            SetupNestedClickEvents(ctl, handler);
    }
