    /// <summary>
    /// On drop down
    /// </summary>
    protected override void OnDropDown(EventArgs e)
    {
        base.OnDropDown(e);
        // Start checking for the dropdown visibility
        _dropDownCheck.Start();
    }
    /// <summary>
    /// Checks when the drop down is fully visible
    /// </summary>
    private void dropDownCheck_Tick(object sender, EventArgs e)
    {
        // If the drop down has been fully dropped
        if (DroppedDown)
        {
            // Stop the time, send a listbox update
            _dropDownCheck.Stop();
            Message m = GetControlListBoxMessage(this.Handle);
            WndProc(ref m);
        }
    }
