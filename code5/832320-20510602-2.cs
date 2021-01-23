    public void dotest(){
        Task.Factory.StartNew(() => {
                // ... do some testing
                Thread.Sleep(1000);
            }
        ).ContinueWith(task => {
                Test = "Past point one";
            }, 
        TaskScheduler.FromCurrentSynchronizationContext());
    }
