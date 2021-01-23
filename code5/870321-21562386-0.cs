    namespace YourSession
    {
        public static class SessionProperties
       {       
          public static UserAccount UserAccount
        {
            get
            {
                return (UserAccount)HttpContext.Current.Session["UserAccount"];
            }
            set
            {
                HttpContext.Current.Session["UserAccount"] = value;
            }
        }
       }
    }
