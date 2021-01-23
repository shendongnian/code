    void Loop(CancellationToken token)
    {
      var remoteEP = default(IPEndPoint);
      while (!token.IsCancellationRequested)
      {
        var data = client.Receive(ref remoteEP);
    
        yourForm.Invoke(DataReceived, data);
      }
    }
