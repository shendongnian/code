    LongRunningOperationAsync().ContinueWith(t=>
                                             {
                                                  if(t.Exception == null)
                                                  {
                                                     //Something bad happen
                                                  }
                                                  //Task finished
                                             });
