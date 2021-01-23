    public interface IUser
    {
       string Username { get; set; }
       string Password { get; set; }
    }
    public interface IUser<TRole> : IUser where TRole : IRole
    {  
       IList<TRole> Roles { get; set; }
    }
    
    public interface IRole
    {
       string Name { get; set; }
    }
    public interface IRole<TUser> : IRole where TUser : IUser
    {
       IList<TUser> Users { get; set; }
    }
    
    public class User : IUser<Role>
    {
       public string Username { get; set; }
       public string Password { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public IList<Role> Roles { get; set; }
    }
    
    public class Role : IRole<User>
    {
       public string Name { get; set; }
       public IList<User> Users { get; set; }
    }
