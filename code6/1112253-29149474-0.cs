    private async Task<List<PingReply>> PingAsync(List<HostObject> HostList)
    {
        var tasks = HostList.Select(HostName => new Ping().SendPingAsync(HostName.ToString(), 2000));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }
