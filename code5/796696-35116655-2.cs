     private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
             ...
            }
            catch (Exception e)
            {
              if (_socket != null) _socket.Dispose();
            }
        }
