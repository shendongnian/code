     public class BlackListAttribute : AuthorizeAttribute
     {
            public string BlackListedUsers { get; set; }
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                if (user is in _blackListedUsers) {
                  return false;
                }
            }
    }
