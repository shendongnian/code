    public bool OpenPort()
    {
        try
        {
            if (_port != null && _port.IsOpen)
            {
                new Thread(_port.Close).Start();
                Thread.Sleep(500);
            }
    
            // Open the port code
    
            return true;
        }
        catch (Exception e)
        {
            // Error handling code
            return false;
        }
    }
