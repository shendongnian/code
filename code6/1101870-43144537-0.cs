    using MongoDB.Driver;
    using MongoDB.Driver.Core.Clusters;
    var mongoClient = new MongoClient("localhost")
    mongoClient.Cluster.DescriptionChanged += Cluster_DescriptionChanged;
    public void Cluster_DescriptionChanged(object sender, ClusterDescriptionChangedEventArgs e)
    {
        switch (e.NewClusterDescription.State)
        {
            case ClusterState.Disconnected:
                break;
            case ClusterState.Connected:
                break;
        }
    }
