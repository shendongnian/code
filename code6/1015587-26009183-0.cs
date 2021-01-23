    WindowsIdentity newId = new WindowsIdentity(token);
    var task2 = Task.Factory.StartNew(() => 
                                     {
                                         using(WindowsImpersonationContext wi = newId.Impersonate())
                                         {
                                              UploadFunction();
                                         }
                                     },
                                     tokenSource.Token,
                                     TaskCreationOptions.LongRunning,
                                     TaskScheduler.Default
                                   );
               
                                      
