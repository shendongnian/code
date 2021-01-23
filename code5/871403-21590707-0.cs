    public class UserRepository 
    {
         private readonly _dbContext MyDbContext;
 
         public IEnumberable<User> getActiveUsers() 
         {
              // whatever you do to find the active users
              return _dbContext.Where(user => user.Active == true);
         }
    }
