    public void buttonConnect_Click(object sender, EventArgs e)
    {
        // check if the comport is created, else show a message and return,
        TryDisconnect();
        var portname = GetCurrentComPort();
        if (portname == null)
            return;
        try
        {
            _comport = new ComPort(portname, 9600);
        }
        catch(Exception exception)
        {
            // try to create a better message here :-)
            MessageBox.Show("Something went wrong....");
        }
    }
    public void buttonDisconnect_Click(object sender, EventArgs e)
    {
        TryDisconnect();
    }
    public void TryDisconnect()
    {
        if( _comport != null)
        {
            _comport.Dispose();
            _comport = null;
        }
    }
