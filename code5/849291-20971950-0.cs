    public void FillBuf(object sender)
    {
        var handler = (Socket)sender;
    
        while (true)
        {
            // Note: use local variables here. You really don't want these variables
            // getting mixed up between threads etc.
            int received = 0;
            byte[] bytes = new byte[512];
    
            while (received < bytes.Length)
            {
                int block = handler.Receive(bytes, received, bytes.Length - received,
                                            SocketFlags.None);
                received += block;
            }
            que.Enqueue(bytes);
        }
    }
