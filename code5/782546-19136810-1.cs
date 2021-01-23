    var task = Task.Factory.StartNew(() =>
                          {
                              //This invokes UI specific code inside module initialization
                              LoadDataNow();
                          });
    task.ContinueWith(t => StatusMessageVisibility = Visibility.None, 
                           TaskScheduler.FromCurrentSynchronizationContext());
