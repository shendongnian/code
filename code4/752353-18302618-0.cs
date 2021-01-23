    public void Get()
        {
            string data;
            string input;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(ipep);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server");
                Console.WriteLine(e.ToString());
                return;
            }
            NetworkStream ns = new NetworkStream(socket);
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            data = sr.ReadLine();
            Console.WriteLine(data);
            while (true)
            {
                input = Console.ReadLine();
                if (input == "exite")
                    break;
                sw.WriteLine(input);
                sw.Flush();
                data = sr.ReadLine();
                Console.WriteLine(data);
            }
            Console.WriteLine("Disconnected from server...");
            socket.Close();
            ns.Close();
            sr.Close();
            sr.Close();
        }
