        public class UserData
        {
            public UserData(string username)
            {
                UserName = username;
                ConnectionIds = new HashSet<string>();
            }
    
            public string UserName { get; private set; }
            public HashSet<string> ConnectionIds { get; private set; } 
        }
    
        public static class ConnectionStore
        {
            private static readonly ConcurrentDictionary<string, UserData> _userData = new ConcurrentDictionary<string, UserData>();
    
            public static void Join(string username, string connectionId)
            {
                _userData.AddOrUpdate(username, 
                    u => new UserData(u),                   /* Lambda to call when it's an Add */
                    (u, ud) => {                            /* Lambda to call when it's an Update */
                        ud.ConnectionIds.Add(connectionId);
                        return ud;
                });
            }
        }
