    public class SessionWrapper
    {
        public Session Session { get; set; }
        public SessionObject SessionObject
        {
            get
            {
                return Session["SessionObject"] as SessionObject;
            }
            set
            {
                Session["SessionObject"] = value;
            }
        }
    }
