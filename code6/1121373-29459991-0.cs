    public bool IsClusterConnceted
    {
        get
        {
            return _client.Cluster.Description.State == ClusterState.Connected;
        }
    }
