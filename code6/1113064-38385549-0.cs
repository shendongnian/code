    internal class ClientsDatabaseIsolator : IHubCallerConnectionContext<object>
    {
        private readonly string _database;
        private readonly IHubCallerConnectionContext<dynamic> _clients;
    
        public ClientsDatabaseIsolator(string database, IHubCallerConnectionContext<dynamic> clients)
        {
            if (database == null) throw new ArgumentNullException(nameof(database));
            this._database = database;
            this._clients = clients;
        }
    
        private string PrefixDatabase(string group)
        {
            return string.Concat(_database, ".", group);
        }
    
        public dynamic AllExcept(params string[] excludeConnectionIds)
        {
            return _clients.Group(_database, excludeConnectionIds);
        }
    
        public dynamic Client(string connectionId)
        {
            return _clients.Client(connectionId);
        }
    
        public dynamic Clients(IList<string> connectionIds)
        {
            return _clients.Clients(connectionIds);
        }
    
        public dynamic Group(string groupName, params string[] excludeConnectionIds)
        {
            return _clients.Group(PrefixDatabase(groupName), excludeConnectionIds);
        }
    
        public dynamic Groups(IList<string> groupNames, params string[] excludeConnectionIds)
        {
            return _clients.Groups(groupNames.Select(PrefixDatabase).ToList(), excludeConnectionIds);
        }
    
        public dynamic User(string userId)
        {
            return _clients.User(userId);
        }
    
        public dynamic Users(IList<string> userIds)
        {
            return _clients.Users(userIds);
        }
    
        public dynamic All
        {
            get { return _clients.Group(_database); }
        }
    
        public dynamic OthersInGroup(string groupName)
        {
            return _clients.OthersInGroup(PrefixDatabase(groupName));
        }
    
        public dynamic OthersInGroups(IList<string> groupNames)
        {
            return _clients.OthersInGroups(groupNames.Select(PrefixDatabase).ToList());
        }
    
        public dynamic Caller
        {
            get { return _clients.Caller; }
        }
    
        public dynamic CallerState
        {
            get { return _clients.CallerState; }
        }
    
        public dynamic Others
        {
            get { return _clients.OthersInGroup(_database); }
        }
    }
