    public delegate AbstractProxyLogic OnNewClient(HttpSocket ss);
    
    public void Start(OnNewClient onConnection)
    {
        // ...
    }
