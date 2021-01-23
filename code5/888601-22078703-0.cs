    private async Task<List<PingReply>> PingAsync()
    {
        Ping pingSender = new Ping();
        var tasks = theListOfIPs.Select(ip => pingSender.SendPingAsync(ip, 2000));
        await Task.WhenAll(tasks);
        return tasks.Select(t => t.Result).ToList();
    }
