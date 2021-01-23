    public class AppPrincipal : IAppPrincipal
    {
       public int UserId { get; set; }
       public string Role { get; set; }
       //other properties
       public AppPrincipal(int userId, string role) {
           UserId  = userId;
           Role = role;
       }
    }
