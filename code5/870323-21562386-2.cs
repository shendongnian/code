    namespace YourSession
    {
        public static class SessionProperties
       {       
          public static UserAccount UserAccountx
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
