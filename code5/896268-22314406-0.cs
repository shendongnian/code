    StartListening(){
      listener.Bind(localEndPoint);
      listener.Listen(100);
      GetConnection(listener);
    }
    
    
    private GetNewConnection (Socket listener){
      Console.WriteLine("Waiting for a connection...");
      listener.BeginAccept(new AsyncCallback(OnNewConnection),
                           listener);
    }
    
    private OnNewConnection(IAsyncResult ar){
      Socket listener = (Socket) ar.AsyncState;
      Socket handler = listener.EndAccept(ar);
      GetConnection(listener);
      //... 
    }
