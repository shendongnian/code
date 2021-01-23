    void Loop(CancellationToken token)
    {
      while (!token.IsCancellationRequested)
      {
        var data = client.Receive();
    
        yourForm.Invoke(DataReceived, data);
      }
    }
