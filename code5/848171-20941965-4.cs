    public class UserListCache : List<User>
    {
        /// <summary>
        /// const cache string
        /// </summary>
        const string userCacheString = "_userCacheList";
    
        /// <summary>
        /// current list of users
        /// </summary>
        public static UserListCache Current
        {
            get
            {
                if (HttpContext.Current == null)
                    throw new Exception("NO CONTEXT");
                var userList = HttpContext.Current.Cache[userCacheString] as UserListCache;
                if (userList == null)
                {
                    userList = new UserListCache();
                    HttpContext.Current.Cache[userCacheString] = new UserListCache();
                }
                return userList;
            }
        }
    
        /// <summary>
        /// default constructor
        /// </summary>
        public UserListCache()
        {
            this.fillUsers();
        }
    
        /// <summary>
        /// clear the list
        /// </summary>
        public new void Clear()
        {
            base.Clear();
            this.fillUsers();
        }
    
        /// <summary>
        /// fills the users from the database
        /// </summary>
        void fillUsers()
        {
            //TODO: Get from DB
        }
    }
