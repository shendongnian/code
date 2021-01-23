    void SetEnabledForAllControls(ControlCollection controls, bool value)
    {
        foreach (Control control in controls)
        {
            control.Enabled = value;
            SetEnabledForAllControls(control.Controls, value);
        }
    }
