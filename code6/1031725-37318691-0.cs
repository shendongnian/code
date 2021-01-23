    public class SessionController
    {
        const string sessionname = "UserContext";
        public static SessionDetail UserContext
        {
            get
            {
                return System.Web.HttpContext.Current.Session[sessionname] as SessionDetail;
            }
            set
            {
                HttpContext.Current.Session[sessionname] = value;
            }
        }
    }
     public class SessionDetail
     {
          public string Employee_ID { get; set; }
     }
