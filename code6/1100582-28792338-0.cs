    private static ConnectionMultiplexer _redis;
    private static readonly Object _multiplexerLock = new Object();
            
    private void ConnectRedis()
    {
        try
        {
            _redis = ConnectionMultiplexer.Connect("...<connection string here>...");
        }
        catch (Exception ex)
        {
            //exception handling goes here
        }
    }
    
    
    private ConnectionMultiplexer RedisMultiplexer
    {
        get
        {
            lock (_multiplexerLock)
            {
                if (_redis == null || !_redis.IsConnected)
                {
                    ConnectRedis();
                }
                return _redis;
            }
        }
    }
