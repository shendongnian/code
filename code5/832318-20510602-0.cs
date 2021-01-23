    public void dotest(){
        Task.Factory.StartNew( () => {
            ... do some testing
        }).ContinueWith(() => {
            Test = "Past point one"
        }, TaskScheduler.FromCurrentSynchronizationContext()
        );
    }
