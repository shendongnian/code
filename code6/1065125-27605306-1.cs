    public static class InfoHelper
    {
        public static Dictionary<string, string> Info
        {
            get
            {
                Dictionary<string, string> d
                     = HttpContext.Current.Cache["someId"] as Dictionary<string, string>;
                if (d == null)
                {
                    d = HttpContext.Current.Cache["someId"] = SomeCreationMethod();
                }
                return d;
            }
    }
