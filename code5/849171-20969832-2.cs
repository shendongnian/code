    // Buggy connection wrapper
    public class ConnectionWrapper : IDisposable
    { 
        public ConnectionWrapper() 
        {
            this.connection = new Connection();
            // do some other stuff, some of which might throw
        }
        private Connection connection;
        // ...
        // IDisposable stuff.
    }
    private void Client() 
    {
        using (var connection = new ConnectionWrapper())
        {
            // do something with the connection, assuming we're safe
        }
    }
