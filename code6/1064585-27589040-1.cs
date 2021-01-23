        public interface IUserService
        {        
           User GetUserByID(int userId);        
        }
    
        public class UserService : IService
        {
          private readonly UserContext _context;
        
          //Inject your mock or real context here
          public UserService(UserContext context)
          { 
             this._context = context;
          }
    
          //Implement IUserService
          public User GetUserByID(int userId)
          {  
              _context.Users.Where(u=>u.ID==userId).FirstOrDefault();
          }
        }
