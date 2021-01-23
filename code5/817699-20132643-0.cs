    public void ManageProgress()
    {
        // This queues up a message to run process.Begin(), 
        // but will not begin until this function and other callers ahead 
        // of it have returned control to the Dispatcher
        Dispatcher.BeginInvoke((Action)(() => process.Begin()));
        // This is waiting on a response from process, but it will get 
        // stuck in the loop here. Also, using Dispatcher.Invoke<> is suspect here.
        // By looping here, we prevent the prior call to BeginInvoke from working.
        while (!Dispatcher.Invoke<bool>(process.IsComplete))
        {
            // ...
        }
        this.Close();
    }
