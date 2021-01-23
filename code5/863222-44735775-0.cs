    string uri = "...";
    string user = "...";
    string workspace = "...";
    string pass = "..."; 
    int id = 12345; // the actual changelist number
    string depotPath = "//depot/foo/main/...";
    int maxItemsToSync = 10000;
    
    Server server = new Server(new ServerAddress(uri));
    Repository rep = new Repository(server);
    
    server = new Server(new ServerAddress(uri));
    rep = new Repository(server);
    Connection con = rep.Connection;
    con.UserName = user;
    con.Client = new Client();
    con.Client.Name = workspace;
    
    // connect
    bool connected = con.Connect(null);
    if (connected)
    {
        try
        {
            // attempt a login
            Perforce.P4.Credential cred = con.Login(pass);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            con.Disconnect();
            connected = false;
        }
    
        if (connected)
        {
            // get p4 info and show successful connection
            ServerMetaData info = rep.GetServerMetaData(null);
            Console.WriteLine("CONNECTED TO " + info.Address.Uri);
            Console.WriteLine("");
    
            try
            {
                Options opts = new Options();
    
                // uncomment below lines to only get a preview of the sync w/o updating the workspace
                //SyncFilesCmdOptions syncOpts = new SyncFilesCmdOptions(SyncFilesCmdFlags.Preview, maxItemsToSync);
                SyncFilesCmdOptions syncOpts = new SyncFilesCmdOptions(SyncFilesCmdFlags.None, maxItemsToSync);
    
                VersionSpec version = new ChangelistIdVersion(id);
                PathSpec path = new DepotPath(depotPath);
                FileSpec depotFile = new FileSpec(path, version);
    
                IList<FileSpec> syncedFiles = rep.Connection.Client.SyncFiles(syncOpts, depotFile);
                //foreach (var file in syncedFiles)
                //{
                //    Console.WriteLine(file.ToString());
                //}
                Console.WriteLine($"{syncedFiles.Count} files got synced!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
            }
            finally
            {
                con.Disconnect();
            }
        }
    }
