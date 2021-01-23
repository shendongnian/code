    public class UserCache : IEnumerable<User>
    {
        /// <summary>
        /// const cache string
        /// </summary>
        const string userCacheString = "_userCacheList";
    
        /// <summary>
        /// current list of users
        /// </summary>
        public static UserCache Current
        {
            get
            {
                if (HttpContext.Current == null)
                    throw new Exception("NO CONTEXT");
                var userList = HttpContext.Current.Cache[userCacheString] as UserCache;
                if (userList == null)
                {
                    userList = new UserCache();
                    HttpContext.Current.Cache[userCacheString] = new UserCache();
                }
                return userList;
            }
        }
    
        /// <summary>
        /// default constructor
        /// </summary>
        public UserCache()
        {
        }
    
        /// <summary>
        /// the list of users
        /// </summary>
        List<User> users;
    
        /// <summary>
        /// adds a user
        /// </summary>
        /// <param name="user"></param>
        public void Add(User user)
        {
            if (this.Contains(user))
                return;
            this.users.Add(user);
        }
    
        /// <summary>
        /// removes a user
        /// </summary>
        /// <param name="user"></param>
        public void Remove(User user)
        {
            if (this.Contains(user))
                return;
            this.users.Remove(user);
        }
    
        /// <summary>
        /// clears a user
        /// </summary>
        public void Clear()
        {
            this.users = null;
        }
    
            
    
        /// <summary>
        /// fills the users from the database
        /// </summary>
        void fillUsers()
        {
            this.users = new List<User>();
            //TODO: Get from DB
        }
    
        /// <summary>
        /// gets the enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<User> GetEnumerator()
        {
            if (this.users == null)
                fillUsers();
            foreach (var user in users)
                yield return user;
        }
    
        /// <summary>
        /// gets the enumerator
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    
    public class User
    {
        public string UserName { get; set; }
    
        public Guid UserID { get; set; }
    
        public string Email { get; set; }
    }
