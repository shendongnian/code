     private void ListenMethod()
        {
            listener = new TcpListener();
            listener.Start();
    
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
            }
        }
