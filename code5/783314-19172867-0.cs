                // define the server, repository and connection
                Server server = new Server(new ServerAddress(uri));
                Repository rep = new Repository(server);
                Connection con = rep.Connection;
                // use the connection varaibles for this connection
                con.UserName = user;
                con.Client = new Client();
                con.Client.Name = ws_client;
              
                // connect to the server
                con.Connect(null);
