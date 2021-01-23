    public static async Task<bool> PingAsync(string host)
    {
        try
        {
            var ping = new System.Net.NetworkInformation.Ping();
            var reply = await ping.SendTaskAsync(host);
    
            return (reply.Status == System.Net.NetworkInformation.IPStatus.Success);
        }
        catch { return false; }
    }
