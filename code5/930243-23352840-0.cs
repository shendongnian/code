    public partial class Form1
    {
        MyClient _client;
        
        protected MyClient client
        {
            get
            {
                // Check if we need to reconnect.
                if (_client == null || client.wasDisconnected())
                    _client = new MyClient();
                return _client;
            }
        }
        
        // ...
    }
