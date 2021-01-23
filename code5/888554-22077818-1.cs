    public bool OpenPort()
    {
        try
        {
            if (_port != null && _port.IsOpen)
            {
                new Thread(CloseSerialPortCleanly).Start();
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
    
    private void CloseSerialPortCleanly()
    {
        try
        {
            if (_port != null && _port.IsOpen)
            {
                _port.Close();
                _port.Dispose();
                _port = null;
            }
        }
        catch
        {
             // Error handling code
        }
    }
