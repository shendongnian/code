    private TcpClient server = new TcpClient();
    void listen(){
        try {
            IPAddress IP = IPAddress.Loopback // this is your localhost IP
            await server.ConnectAsync(IP,10000); // IP, port number
            if(server.Connected) {
               NetworkStream stream = server.GetStream();
               
               while (server.Connected) {
                   byte[ ] buffer = new byte[server.ReceiveBufferSize];
                   int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                   if (read > 0 ){
                        // you have received a message, do something with it
                   }
               }
            }
        }
        catch (Exception ex) {
             // display the error message or whatever
             server.Close();
        }
    }
