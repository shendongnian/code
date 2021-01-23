    public class UserCache
     {
      private Dictionary<int, User> _users = new Dictionary<int, User>();
     private readonly object _syncLock = new object(); 
     public User GetUser(int id)
    {
       User u = null;
        lock (_syncLock)
        { 
		
            if (_users.containsKey(id))
                return _users[id];
        
        //The below line is threadsafe, so no worries on that.
        u = RetrieveUser(id); // Method to retrieve from database;
       
            _users.Add(id, u);
        }
        return u;
    }
