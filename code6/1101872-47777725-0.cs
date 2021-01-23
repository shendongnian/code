        private static bool ProbeForMongoDbConnection(string connectionString, string dbName)
        {
            var probeTask = 
                    Task.Run(() =>
                                {
                                    var isAlive = false;
                                    var client = new MongoDB.Driver.MongoClient(connectionString);
                                            
                                    for (var k = 0; k < 6; k++)
                                    {
                                        client.GetDatabase(dbName);
                                        var server = client.Cluster.Description.Servers.FirstOrDefault();
                                        isAlive = (server != null && 
                                                   server.HeartbeatException == null && 
                                                   server.State == MongoDB.Driver.Core.Servers.ServerState.Connected);
                                        if (isAlive)
                                        {
                                            break;
                                        }
                                        System.Threading.Thread.Sleep(300);
                                    }
                                    return isAlive;
                                });
            probeTask.Wait();
            return probeTask.Result;
        }
