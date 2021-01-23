    private void Set_status(string text, string Qmgr)
    { 
        if (this.InvokeRequired)
        {
        this.Invoke(new ReceivedEventHandler(Set_status), new Object[] {text, Qmgr});                
        }
        else 
        {
        }
    }
