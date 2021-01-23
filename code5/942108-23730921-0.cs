        Dispatcher.BeginInvoke(() =>
                     {
                         //You can show the progress bar in here
                         var result =  browserControl.InvokeScript("RetrieveAccounts",
                                                         "http://some.service.net/",
                                                         "Plain",
                                                         "arg1",
                                                         "arg2",
                                                         "arg3");
                     }); 
