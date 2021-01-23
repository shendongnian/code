    Task x = Task.Factory.StartNew(() =>
                                               {
                                                   DoSomething();
                                               }
                ).ContinueWith((task) =>
                                   {
                                       DoSomething();
                                   });
                                               
