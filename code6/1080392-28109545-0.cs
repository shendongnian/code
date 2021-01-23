    var task = Task.Run(() => 
                       {
                             if (cts.Token.IsCancellationRequested)
                             { 
                                   // Do stuff
                                   return;
                             }
                       }, cts.Token);
