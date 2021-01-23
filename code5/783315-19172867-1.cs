    The issue got resolved. I have used below code
    
    // define the server, repository and connection
                    Server server = new Server(new ServerAddress(uri));
                    Repository rep = new Repository(server);
                    Connection con = rep.Connection;
    
    
                    // use the connection varaibles for this connection
                    con.UserName = user;
                    con.Client = new Client();
                    con.Client.Name = ws_client;
    
                    Options opconnect = new Options();
                    //opconnect.Add("-p", "");
                    opconnect.Add("-p", password);
                    
                    
                    // connect to the server
                    con.Connect(opconnect);
                    //con.Connect(null);
                    con.Login(password);
