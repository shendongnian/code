    private void CheckAndAddControl<ControlType>()
        where ControlType : MasterControl, new()
    {
        bool currentControl = false;
    
        foreach (Control c in this.Controls)
        {
            if (c is ControlType)
            {
                currentControl = true;
                break;
            }
        }
    
        if (currentControl)
        {
            TimedMessageBox timedMessage = new TimedMessageBox("There is currently an open form.  Please close the current control before opening another.");
            timedMessage.ShowDialog();
        }
        else
        {
            var c = new ControlType();
            this.Controls.Add(c);
            Position_Control(c);
            c.Show();
        }
    }
