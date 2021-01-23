    var databases = _client.ListDatabasesAsync().Result;
	databases.MoveNextAsync(); // Force MongoDB to connect to the database.
	if (_client.Cluster.Description.State == ClusterState.Connected)
	{
	    // Database is connected.
	}
