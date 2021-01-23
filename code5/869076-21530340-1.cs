    private void DisableControls() 
    {
        var Controls = this.Controls.OfType<TextBox>();
        foreach (Control c in Controls) 
        {
           ((TextBox)c).Enabled = false;
        }
        
    }
    
    private void EnableControls()
    {
        var Controls = this.Controls.OfType<TextBox>();
        foreach (Control c in Controls) 
        {
           ((TextBox)c).Enabled = true;
           
        }
    }
