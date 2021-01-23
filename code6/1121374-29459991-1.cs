    public bool IsServerConnceted
    {
        get
        {
            return _client.Cluster.Description.Servers.Single().State == ServerState.Connected;
        }
    }
