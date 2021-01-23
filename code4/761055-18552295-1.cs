    static void beginConnection(IAsyncResult iar)
            {
                Console.WriteLine("Client connected");
                Socket s = (Socket)iar.AsyncState;
                server = s.EndAccept(iar);
    
                server.Listen(4); // this line was initially absent
                server.BeginAccept(beginConnection, s);
            }
