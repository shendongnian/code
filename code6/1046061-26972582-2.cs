      var UISyncContext = TaskScheduler.FromCurrentSynchronizationContext();
     task.ContinueWith(() =>
                        {
                            var resul = task.Result;  
                        },UISyncContext); 
