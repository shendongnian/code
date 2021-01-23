    public class User
    {
      public string Username{get;set;}
      public string Password{get;set;}
    }
    
    public interface IUserManager
    {
      bool Register(User user);
    }
    
    public class UserManager : IUserManager
    {
      public bool Register(User user)
      {
        // register your user here
      }
    }
