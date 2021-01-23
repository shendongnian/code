        Socket socket;
  
        try
        {
            // prepare socket
            try
            {
                socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch
            {
                log.write("socket preparation failed");
                throw;
            }
            // bind
            try
            {
                socket.Bind(endPoint);
            }   
            catch
            {
                log.write("Bind() failed");
                throw;
            }
            // enable listening
            try
            {
                socket.Listen(1000);
            }
            catch
            {
                log.write("Listen() failed");
                throw;
            }
        }
        finally
        {
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
