    static void Main()
    {
        IPEndPoint socketAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 54165);
        var vlcServerProcess = Process.Start(@"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe", "-I rc --rc-host " + socketAddress.ToString());
                        
        try
        {
            Socket vlcRcSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            vlcRcSocket.Connect(socketAddress);
            // start another thread to look for responses and display them
            Task listener = Task.Factory.StartNew(() => Receive(vlcRcSocket));
            Console.WriteLine("Connected. Enter VLC commands.");
            while(true)
            {
                string command = Console.ReadLine();
                if (command.Equals("quit")) break;
                Send(vlcRcSocket, command);
            }
            Send(vlcRcSocket, "quit"); // close vlc rc interface and disconnect
            vlcRcSocket.Disconnect(false);
        }
        finally
        {
            vlcServerProcess.Kill();
        }
    }
    private static void Send(Socket socket, string command)
    {
        // send command to vlc socket, note \n is important
        byte[] commandData = UTF8Encoding.UTF8.GetBytes(String.Format("{0}\n", command));
        int sent = socket.Send(commandData);
    }
    private static void Receive(Socket socket)
    {
        do
        {
            if (socket.Connected == false)             
                break;
            // check if there is any data
            bool haveData = socket.Poll(1000000, SelectMode.SelectRead);
            if (haveData == false) continue;
            byte[] buffer = new byte[socket.ReceiveBufferSize];
            using (MemoryStream mem = new MemoryStream())
            {
                while (haveData)
                {
                    int received = socket.Receive(buffer);
                    mem.Write(buffer, 0, received);
                    haveData = socket.Poll(1000000, SelectMode.SelectRead);
                }
                Console.WriteLine(Encoding.UTF8.GetString(mem.ToArray()));
            }    
        } while (true);         
    }
