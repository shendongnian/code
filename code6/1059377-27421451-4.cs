    public class SessionContainer
    {
    
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
    
    public class YourClass1
    {
        public SessionObject Session { get; private set; }
    
        public YourClass1
        {
            this.Session = new SessionContainer();
        }
    }
