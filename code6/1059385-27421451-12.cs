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
        public SessionContainer Session { get; private set; }
    
        public YourClass1
        {
            this.Session = new SessionContainer();
        }
    }
    public class YourClass2
    {
        public SessionContainer Session { get; private set; }
    
        public YourClass2
        {
            this.Session = new SessionContainer();
        }
    }
