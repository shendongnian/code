    private void EnableDisableControls(Control.ControlCollection Controls, bool state)
    {
        foreach (Control c in Controls)
        {
            c.Enabled = state;
            if (c is ComboBox)
            {
                // do something here with comboBoxes 
            }
 
            if (c.Controls.Count > 0)
            {
                this.EnableDisableControls(c.Controls, state);
            }
        }
    }
