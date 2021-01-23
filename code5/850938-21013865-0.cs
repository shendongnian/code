    TcpListener listener;
    void Serve(){
      while(true){
        var client = listener.AcceptTcpClient();
        Task.Run(() => this.HandleConnection(client));
        //Or alternatively new Thread(HandleConnection).Start(client)
      }
    }
