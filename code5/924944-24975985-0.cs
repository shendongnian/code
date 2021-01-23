    public class HttpContextBasedUserService : IUserService
    {
        public string UserName
        {
            get { return HttpContext.Current.User.Identity.GetUserName(); }
    
        }
    
        public string UserId
        {
            get { return HttpContext.Current.User.Identity.GetUserId(); }
    
        }
    }
