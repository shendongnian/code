    private static bool CanConnect(string machine)
    {
        using (TcpClient client = new TcpClient())
        {
            if (!client.ConnectAsync(machine, 443).Wait(50)) // Check if we can connect in 50ms
            {
                return false;
            }
        }
    
        return true;
    }
