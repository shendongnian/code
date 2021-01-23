    public static void PingTest()
    {
        const int timeout = 120;
        const string data = "[012345678901234567890123456789]";
        var buffer = Encoding.ASCII.GetBytes(data);
        PingReply reply;
        var success = true;    // Start out optimistic!
        var sender = new Ping();
    
        // Add as many hosts as you want to ping to this list
        var hosts = new List<string> {"www.google.com", "www.432446236236.com"};
    
        // Ping each host and set the success to false if any fail or there's an exception
        foreach (var host in hosts)
        {
            try
            {
                reply = sender.Send(host, timeout, buffer);
    
                if (reply == null || reply.Status != IPStatus.Success)
                {
                    // We failed on this attempt - no need to try any others
                    success = false;
                    break;
                }
            }
            catch
            {
                success = false;
            }
        }
                
        if (success)
        {
            label1.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            label1.ForeColor = System.Drawing.Color.Red;
        }
    }
