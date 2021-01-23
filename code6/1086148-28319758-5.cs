    AutoResetEvent _receive;
    string ReadResponse(int timeout)
    {
        string response = string.Empty;
    
        while (true)
        {
            if (_receive.WaitOne(timeout, false))
            {
                response += _port.ReadExisting();
            }
            else
            {
                if (response.Length > 0)
                    throw new InvalidOperationException("Incomplete response.");
                else
                    throw new InvalidOperationException("No response.");
            }
    
            // Pretty raw implementation, I'm not even sure it covers
            // all cases, a better parsing would be appreciated here.
            // Also note I am assuming verbose V1 output with both \r and \n.
            if (response.EndsWith("\r\nOK\r\n"))
                break;
    
            if (response.EndsWith("\r\n> "))
                break;
    
            if (response.EndsWith("\r\nERROR\r\n"))
                break;
        }
    
        return response;
    }
