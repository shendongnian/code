    public class RedisInstanceManager
    {
        public RedisInstanceCredentials m_redisInstanceCredentials { get; set; }
        public DateTime? m_lastUpdatedDate { get; set; }
        public ConnectionMultiplexer redisClientsFactory { get; set; }
        public Timer _ConnectedTimer;
        public Action _reconnectAction; 
        public RedisInstanceManager(ConnectionMultiplexer redisClients, Action _reconnectActionIncoming)
        {
            string host,port;
            string[] splitArray  = redisClients.Configuration.Split(':');
            host =  splitArray[0];
            port = splitArray[1];
            this.redisClientsFactory = redisClients;
            this.m_redisInstanceCredentials = new RedisInstanceCredentials(host, port);
            this.m_lastUpdatedDate = null;
            _ConnectedTimer = new Timer(connectedTimer, null, 1500, 1500);
            _reconnectAction = _reconnectActionIncoming;
            this.redisClientsFactory.ConnectionRestored += redisClientsFactory_ConnectionRestored;
        }
        private void connectedTimer(object o)
        {
            _ConnectedTimer.Change(Timeout.Infinite, Timeout.Infinite);
            if (!this.redisClientsFactory.IsConnected)
            {
                Console.WriteLine("redis dissconnected");
            }
            _ConnectedTimer.Change(1500,1500);
        }
        void redisClientsFactory_ConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine("Redis Connected again");
            if (_reconnectAction != null)
                _reconnectAction();
        }
        public ConnectionMultiplexer GetClient()
        {
            return this.redisClientsFactory;
        }
    }
