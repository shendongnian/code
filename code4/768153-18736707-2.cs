    public class BlackListAttribute : AuthorizeAttribute
    {
       public string BlackListedUsers { get; set; }
       protected override bool AuthorizeCore(HttpContextBase httpContext)
       {
          if (_blackListedUsers.Contains(user))
          {
             return false;
          }
       }
    }
