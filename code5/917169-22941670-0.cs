    public static class InternalCache
    {
        private static Dictionary<long, UserModel> _Users;
     
    
        public static RefreshUsers()
        {
            Interlocked.Exchange(ref _Users, res);
        }
    
        public static UserModel GetUser(long id)
        {            
            // Read the variable, ensuring we always see the latest value
            var users = Interlocked.CompareExchange(ref _Users, null, null);
            return users[id];            
        }
    }
