    public sealed class Context
    {
        private UserMeta _user = null;
        
        public static Context Current { get { return lazy.Value; } }
        private static readonly Lazy<Context> lazy = new Lazy<Context>(() => new Context());
        public UserMeta User 
        { 
    	    get 
    	    {
    	        if (_user == null) _user =_meta(); 
    	        return _user;
    	    }
        }
    
        private Context()
        {
    
        private UserMeta _meta()
        {
          if (!string.IsNullOrEmpty((string)HttpContext.Current.Session["UserEmail"]))
          {
              //check that the user is in the database first
              var _userTry = 
                Sql.Read.UserByEmail((string)HttpContext.Current.Session["UserEmail"]);
              if (_userTry == null)
              {
                return new UserMeta(
                 new UserMeta((string)HttpContext.Current.Session["UserEmail"]));
              }
              return null;
          }
        }
