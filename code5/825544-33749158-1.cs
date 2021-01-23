    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        if (this.popup.IsOpen)
        {
            this.popup.IsOpen = false; 
            e.Cancel = true;
        }
    
        base.OnBackKeyPress(e);
    }
