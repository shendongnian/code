     public class BlackListAttribute : AuthorizeAttribute
     {
            public List<Users> BlackListedUsers { get; set; }
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                if (user is in _blackListedUsers) {
                  return false;
                }
            }
    }
