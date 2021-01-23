    void SniffPort80()
    {
        byte[] input = new byte[] { 1 };
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
        socket.Bind(new IPEndPoint(IPAddress.Broadcast, 80));
        socket.IOControl(IOControlCode.ReceiveAll, input, null);
        byte[] buffer = new byte[0x10000];
        Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    int len = socket.Receive(buffer);
                    if (len <= 40) continue; //Poor man's check for TCP payload
                    string bin = Encoding.UTF8.GetString(buffer, 0, len); //Don't trust to this line. Encoding may be different :) even it can contain binary data like images, videos etc.
                    Console.WriteLine(bin);
                }
            });
    }
