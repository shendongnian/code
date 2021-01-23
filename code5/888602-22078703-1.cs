    private async Task<List<PingReply>> PingAsync()
    {
        Ping pingSender = new Ping();
        var tasks = theListOfIPs.Select(ip => pingSender.SendPingAsync(ip, 2000));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }
