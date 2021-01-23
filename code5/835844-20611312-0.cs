    private void Receive(IAsyncResult iar)
    {
        Socket server_conn = (Socket)iar.AsyncState;
        
        // check how many bytes we actually received
        var numBytesReceived = server_conn.EndReceive(iar);
        if (!SocketConnected(server_conn))
        {   
            server_conn.Close();
            return;
        }
        // get the received data from the buffer
        if (numBytesReceived > 0)
        {
            for (int i = 0; i < numBytesReceived; i++)
                _commQueue.Enqueue(g_bmsg[i]);
            
            // signal the parser to continue parsing        
            NotifyNewDataReceived();
        }
        
        // continue receiving
        server_conn.BeginReceive(g_bmsg, 0, g_bmsg.Length, SocketFlags.None, new AsyncCallback(Recieve), server_conn);
    }
