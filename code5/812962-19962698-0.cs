    public bool IsPartOfReplicaSet(string connectionString)
    {
      var result = new MongoClient(connectionString)
                 .GetServer()
                 .GetDatabase("admin")
                 .RunCommand("getCmdLineOpts")
                 .Response["parsed"] as BsonDocument;
      return result.Contains("replSet");
    }
