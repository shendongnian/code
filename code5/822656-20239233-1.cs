    public class AppUser
    {
        public string Username { get; set; }
        public string[] Roles { get; set; }
    
        public AppUser()
        {
            var appuser = HttpContext.Session["AppUser"] as AppUser;
            if(appuser == null)
                throw new Exception("User session has expired");
            Username = appuser.Username;
            Roles = appuser.Roles;
        }
    }
    
    
    public class WebAppContext
    {
        const string ContextKey = "WebAppContext";
    
        WebAppContext() { } //empty constructor
        public static WebAppContext Current 
        {
            get
            {
                var ctx = HttpContext.Current.Items[ContextKey] as WebAppContext;
                if(ctx == null)
                {
                    try
                    {
                        ctx = new WebAppContext() { User = new AppUser() };
                    }
                    catch
                    {
                        //Redirect for login
                    }
                    HttpContext.Current.Items.Add(ContextKey, ctx);                     
                }       
                return ctx;     
            }
        }
    
        public AppUser User { get; set; }
    }
