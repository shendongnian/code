    class CustomSocket
    {
      private Socket _socket;
      public Socket Socket
      {
        get
        {
          return _socket;
        }
      }
      
      public CustomSocket(Socket s)
      {
        _socket = s;
      }
    }
