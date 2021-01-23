    client.Name = "myWorkspace";
    client.Initialize(con);
    con.Client = client; // otherwise later things fail somewhat mysteriously
    con.CommandTimeout = new TimeSpan(0); // otherwise the sync is likely to time out
    
    client.SyncFiles(new Perforce.P4.Options()); // sync everything
