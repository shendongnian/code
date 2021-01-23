        var cancelToken = new CancellationTokenSource();
        var taskWithTimeOut = Task.Factory.StartNew( t =>
                                   {
                                      var token = (CancellationToken)t;
                                      while (!token.IsCancellationRequested)
                                      {
                                      }
                                      token.ThrowIfCancellationRequested();
                                   }, cancelToken.Token, cancelToken.Token);
        if (!taskWithTimeOut .Wait(5000, cancelToken.Token)) cancelToken.Cancel();
