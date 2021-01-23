    protected void SomeButton_Click(Object sender, EventArgs e)
    {
        // Task off the work and do not wait, no blocking here.
        Task.Factory.StartNew( () => { PerformConnection(); } );
    }
    private async void PerformConnection()
    {
        // This method acts the way a thread should.  We await the result of async comms.
        // This will not block the UI but also may or may not run on its own thread.
        // You don't need to care about the threading much.
        var conn = await ListenerOrSomething.AwaitConnectionsAsync( /* ... */ );
        // Now you have your result because it awaited.
        using(var newClient = conn.Client())
        {
            var sent = await newClient.SendAsync( /* ... */ );
 
            // more business logic, if needed, even other methods if you want.
        }
    }
