    class Server
    {
        private static Server _instance;
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public static Server Instance 
        { 
            get { return _instance ?? ( _instance = new Server(); }
        }
    }
