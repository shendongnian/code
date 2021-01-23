        static void Main(string[] args)
        {
            //Initialize
            Console.Title = "Pong Server";
            Console.WriteLine("Pong Server");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //Bind socket
            EndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 25565);
            Console.WriteLine("Binding to port 25565");
            serverSocket.Bind(localEndPoint);
            //Listen
            Console.WriteLine("Listening on {0}.", localEndPoint);
            //Prepare EndPoints
            EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
            //Recive Data...
            serverSocket.BeginReceiveFrom(rcvPacket, 0, Data.Size, SocketFlags.None, ref clientEndPoint, new AsyncCallback(ReceiveFrom), null);
            //Initialize TimeSpans
            DateTime Now = DateTime.Now;
            DateTime Start = Now;
            DateTime LastUpdate = Now;
            TimeSpan EllapsedTime;
            TimeSpan TotalTime;
            //Create Physics Objects
            Paddle1 = new Physics2D();
            Paddle2 = new Physics2D();
            Ball = new Physics2D();
            //Loop
            while (alive)
            {
                Now = DateTime.Now;
                TotalTime = Now - Start;
                EllapsedTime = Now - LastUpdate;
                LastUpdate = Now;
                Update(EllapsedTime, TotalTime);
                //Add Sleep to reduce CPU usage;
                Thread.Sleep(1);
            }
            //Press Any Key
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
