    private void DisableControls() 
    {
        var Controls = this.Controls.OfType<TextBox>();
        foreach (Control c in Controls) 
        {
           c.Enabled = false;
        }
        
    }
    
    private void EnableControls()
    {
        var Controls = this.Controls.OfType<TextBox>();
        foreach (Control c in Controls) 
        {
            c.Enabled = true;
           
        }
    }
