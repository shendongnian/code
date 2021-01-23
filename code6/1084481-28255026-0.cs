    public class AspNetUserContext : IUserContext
    {
        public User CurrentUser
        {
            // Do not inject HttpContext in the ctor, but use it
            // here in this property
            get { return new User(HttpContext.Current.User); }
        }
    }
