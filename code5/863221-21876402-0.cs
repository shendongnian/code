            using (Connection con = rep.Connection)
            {
                //setting up client object with viewmap
                Client client = new Client();
                client.Name = "p4apinet_solution_builder_sample_application_client";
                client.OwnerName = "p4username";
                client.Root = "c:\\clientRootPath";
                client.Options = ClientOption.AllWrite;
                client.LineEnd = LineEnd.Local;
                client.SubmitOptions = new ClientSubmitOptions(false, SubmitType.RevertUnchanged);
                client.ViewMap = new ViewMap();
                client.ViewMap.Add("//depotpath/to/your/file.txt", "//" + client.Name + "/clientpath/to/your/file.txt", MapType.Include);
                //connecting to p4 and creating client on p4 server
                Options options = new Options();
                options["Password"] = "p4password";
                con.UserName = "p4username";
                con.Client = new Client();
                con.Connect(options);
                con.Client = rep.CreateClient(client);
                //syncing all files (in this case 1) defined in client's viewmap to the changelist level of 12345
                Options syncFlags = new Options(SyncFilesCmdFlags.Force, 100);
                VersionSpec changeListLevel = new ChangelistIdVersion(12345);
                List<FileSpec> filesToBeSynced = con.Client.ViewMap.Select<MapEntry, FileSpec>(me => new FileSpec(me.Left, changeListLevel)).ToList();
                IList<FileSpec> results = con.Client.SyncFiles(filesToBeSynced, syncFlags);
            }
