    public static class InternalCache
    {
        private static Dictionary<long, UserModel> _Users;
        private static object _lockObj = new Object();
    
        public static RefreshUsers(){
            lock (_lockObj)
            {
                //.............
                // var res=.......
                _Users= res;
            }
        }
    
        public static UserModel GetUser(long id){
            lock (_lockObj)
            {
                return _Users[id];
            }
        }
    }
