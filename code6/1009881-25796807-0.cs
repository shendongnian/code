    private bool userTriggered = true; // True means the user is triggering the event
    private void primaryAntennas_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        // If triggered by other ItemCheck method, let the change take place...
        if (!userTriggered) return;
        // Otherwise we process it and update the other CheckedListBox
        processItemCheckEvent(this.secondaryAntennas, e);
    }
    private void secondaryAntennas_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        // If triggered by other ItemCheck method, let the change take place...
        if (!userTriggered) return;
        // Otherwise we process it and update the other CheckedListBox
        processItemCheckEvent(this.primaryAntennas, e);
    }
    private void processItemCheckEvent(CheckedListBox otherCheckedListBox, ItemCheckEventArgs e)
    {
        // Ignore user changes if we're 'disabled'
        if (e.CurrentValue == CheckState.Indeterminate)
        {
            e.NewValue = CheckState.Indeterminate;
        }
        // Otherwise change the other check box
        else
        {
            // Now we're manipulating the other checkedListBox, 
            // so set userTriggered to false
            userTriggered = false;
            if (e.NewValue == CheckState.Checked)
            {
                otherCheckedListBox.SetItemCheckState(e.Index, CheckState.Indeterminate);
            }
            else
            {
                otherCheckedListBox.SetItemCheckState(e.Index, CheckState.Unchecked);
            }
            // And set it back again now
            userTriggered = true;
        }
    }
