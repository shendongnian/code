        public interface ICache
        {
            bool Enabled { get; }
        }
    
        public class DatabaseConnector
        {
            private Cache cache;
            public ICache Cache { get { return cache; } }
            ...
            private class Cache
            {
                // Implementation with writable property
                public bool Enabled { get; set; }
            }
        }
