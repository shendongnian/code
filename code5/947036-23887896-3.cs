    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    
    namespace CTCServer
    {
        class Server
        {
            //Stores the IP Adress the server listens on
            private IPAddress ip;
    
            //Stores the port the server listens on
            private int port;
    
            //Stores the counter of connected clients. *Note* The counter only gets increased, it acts as "id"
            private int clientCount = 0;
    
            //Defines if the server is running. When chaning to false the server will stop and disconnect all clients.
            private bool running = true;
    
            //Stores all connected clients.
            public List<Client> clients = new List<Client>();
    
            //Event to pass recived data to the main class
            public delegate void GotDataFromCTCHandler(object sender, string msg);
            public event GotDataFromCTCHandler GotDataFromCTC;
    
            //Constructor for Server. If autoStart is true, the server will automaticly start listening.
            public Server(IPAddress ip, int port, bool autoStart = false)
            {
                this.ip = ip;
                this.port = port;
    
                if (autoStart) 
                    this.Run();
            }
    
            //Starts the server.
            public void Run()
            {
                //Run in new thread. Otherwise the whole application would be blocked
                new Thread(() =>
                {
                    //Init TcpListener
                    TcpListener listener = new TcpListener(this.ip, this.port);
                    
                    //Start listener
                    listener.Start();
    
                    //While the server should run
                    while (running)
                    {
                        //Check if someone wants to connect
                        if (listener.Pending())
                        {
                            //Client connection incoming. Accept, setup data incoming event and add to client list
                            Client client = new Client(listener.AcceptTcpClient(), this.clientCount);
                            
                            //Declare event
                            client.internalGotDataFromCTC += GotDataFromClient;
    
                            //Add to list
                            clients.Add(client);
    
                            //Increase client count
                            this.clientCount++;
                        }
                        else
                        {
                            //No new connections. Sleep a little to prevent CPU from going to 100%
                            Thread.Sleep(100);
                        }
                    }
    
                    //When we land here running were set to false or another problem occured. Stop server and disconnect all.
                    Stop();
                }).Start(); //Start thread. Lambda \(o.o)/
            }
    
            //Fires event for the user
            private void GotDataFromClient(object sender, string data)
            {
                //Data gets passed to parent class
                GotDataFromCTC(sender, data);
            }
    
            //Send string "data" to all clients in list "clients"
            public void SendToAll(string data)
            {
                //Call send method on every client. Lambda \(o.o)/
                this.clients.ForEach(client => client.Send(data));
            }
    
            //Stop server
            public void Stop()
            {
                //Exit listening loop
                this.running = false;
    
                //Disconnect every client in list "client". Lambda \(o.o)/
                this.clients.ForEach(client => client.Close());
                
                //Clear clients.
                this.clients.Clear();
            }
        }
    }
 
