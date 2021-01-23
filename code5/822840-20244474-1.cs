    var DefualtTimeout = 5000;
    var cancelToken = new CancellationTokenSource();
    
    var taskWithTimeOut = Task.Factory.StartNew( t =>
                               {
                                  var token = (CancellationToken)t;
                                  while (!token.IsCancellationRequested)
                                  {
                                     // Here your work
                                  }
                                  token.ThrowIfCancellationRequested();
                               }, cancelToken.Token, cancelToken.Token);
----------
       if (!taskWithTimeOut.Wait(DefualtTimeout, cancelToken.Token)) 
          {
             cancelToken.Cancel();
          }
