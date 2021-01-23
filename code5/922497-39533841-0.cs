    public class UserController : ApiController
    {
    
       Database db = new Database();
    
       // construction
       public UserController()
       {
          // Add the following code
          // problem will be solved
          db.Configuration.ProxyCreationEnabled = false;
       }
    
       public IEnumerable<User> GetAll()
        {
                return db.Users.ToList();
        }
    }
