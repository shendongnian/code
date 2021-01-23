    public interface ISignalRConnectionStore
    {
        int Count { get; }
        void Add(string userName, string connectionId);
        IEnumerable<string> GetConnections(string userName);
        void Remove(string userName, string connectionId);
    }
    internal class SignalRConnectionStore : ISignalRConnectionStore
    {
        private readonly Dictionary<string, HashSet<string>> _connections = new Dictionary<string, HashSet<string>>();
        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }
        public void Add(string userName, string connectionId)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(connectionId))
            {
                lock (_connections)
                {
                    HashSet<string> connections;
                    if (!_connections.TryGetValue(userName, out connections))
                    {
                        connections = new HashSet<string>();
                        _connections.Add(userName, connections);
                    }
                    lock (connections)
                    {
                        connections.Add(connectionId);
                    }
                }
            }
        }
        public IEnumerable<string> GetConnections(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                HashSet<string> connections;
                if (_connections.TryGetValue(userName, out connections))
                {
                    return connections;
                }
            }
            return Enumerable.Empty<string>();
        }
        public void Remove(string userName, string connectionId)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(connectionId))
            {
                lock (_connections)
                {
                    HashSet<string> connections;
                    if (!_connections.TryGetValue(userName, out connections))
                    {
                        return;
                    }
                    lock (connections)
                    {
                        connections.Remove(connectionId);
                        if (connections.Count == 0)
                        {
                            _connections.Remove(userName);
                        }
                    }
                }
            }
        }
    }
