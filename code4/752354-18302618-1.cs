    public void Get()
        {
            string data;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipep);
            socket.Listen(10);
            Console.WriteLine("Waiting for a client...");
            Socket client = socket.Accept();
            IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Connected with: {0}, at Port: {1}", newclient.Address, newclient.Port);
            NetworkStream ns = new NetworkStream(client);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            string welcome = "Welcome to my test server";
            sw.Write(welcome);
            sw.Flush();
            while (true)
            {
                try
                {
                    data = sr.ReadLine();
                }
                catch (IOException)
                {
                    break;
                }
                Console.WriteLine(data);
                sw.WriteLine(data);
                sw.Flush();
            }
            Console.WriteLine("Disconnected from {0}", newclient.Address);
            sw.Close();
            ns.Close();
            sr.Close();
        }
