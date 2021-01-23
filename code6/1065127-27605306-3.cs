    public static class InfoHelper
    {
        public static ConcurrentDictionary<string, string> Info
        {
            get
            {
                ConcurrentDictionary<string, string> d
                     = HttpContext.Current.Cache["someId"] as ConcurrentDictionary<string, string>;
                if (d == null)
                {
                    d = HttpContext.Current.Cache["someId"] = SomeCreationMethod();
                }
                return d;
            }
    }
