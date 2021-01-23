    Task.Factory.StartNew(() =>
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();
            while (true)
            {
                Socket socket = listener.AcceptSocket();
                Task.Factory.StartNew(() =>
                {
                    byte[] b = new byte[100];
                    int k = socket.Receive(b);
                });
            }
        });
