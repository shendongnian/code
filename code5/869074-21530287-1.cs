    private void ControlDisabler(Control c)
    {
        if(c != Button1)
        {
            c.Enabled = false;
        }
    }
    private void ControlEnabler(Control c)
    {
        if(c != Button1)
        {
            c.Enabled = true;
        }
    }
