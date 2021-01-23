    private void DisableControls()
    {
        foreach (Control control in Controls)
        {
            control.Enabled = false;
        }
    }
