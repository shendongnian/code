    for(var i=0; i < taskCount; ++i)
    {
        Task.Factory.StartNew(() => // some long running stuff which returns string)
                    .ContinueWith(t => this.lst1.Items.Add(t.Result),
                                  TaskScheduler.FromCurrentSynchronizationContext()); 
    }
