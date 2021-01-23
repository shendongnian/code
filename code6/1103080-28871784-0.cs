    public class DatabaseConnector
    {
        public Caching Cache { get; set; }
        //More properties
        //some methods
        public DatabaseConnector(string[] paramters)
        {
            Connect(paramters);
        }
        protected void Connect(string[] paramters)
        {
            ICaching Cache = new Caching();
            Cache.Enabled = true;
        }
        private interface ICaching
        {
            bool Enabled { get; set; }
        }
        public class Caching : ICaching
        {
            private bool _enabled { get; set; }
            public Caching()
            {
                _enabled = false;
            }
            bool ICaching.Enabled
            {
                get { return _enabled; }
                set { _enabled = value; }
            }
        }
    }
