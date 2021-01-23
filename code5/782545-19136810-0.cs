    var task = Task.Factory.StartNew(() =>
                          {
                              //This invokes UI specific code inside module initialization
                              LoadDataNow();
                          });
    task.ContinueWith(t => new Task(() => StatusMessageVisibility = Visibility.None, 
                           TaskScheduler.FromCurrentSynchronizationContext());
