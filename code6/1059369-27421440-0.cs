    public static class MyExtensions
    {
        public static void SetSessionObject(this object) 
        {
            Session["SessionObject"] = value;
        }
        public static SessionObject GetSessionObject(this object)
        {
            return Session["SessionObject"] as SessionObject;
        }
    }
