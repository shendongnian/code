    protected override bool ProcessTabKey(bool forward)
    {
        //find out where we are
        Control startingFocus = this.ActiveControl;
        //go to the next control
        SelectNextControl(startingFocus, forward, true, true, true);
            
        //find out if we still wanted to go there, (tabstop might have been changed in a SelectedIndexChanged)
        Control newNext = GetNextControl(startingFocus, forward);
        while (!newNext.TabStop)
        {
            newNext = GetNextControl(newNext, forward);
        }
        //if we are in the wrong place, move to the right place
        if (this.ActiveControl != newNext)
        {
            newNext.Focus();
        }
        return true;
    }
