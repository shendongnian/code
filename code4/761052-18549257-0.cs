    while (clientSocket.Connected)//checks connected
    {             
        try
        {
            clientSocket.BeginReceive(so.buffer, 0, 200, SocketFlags.None, new AsyncCallback(wait),so);//says begin receive and continues to do endlessly
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);
         }                
    }
