    public static class InfoHelper
    {
        public static ConcurrentDictionary<string, string> Info
        {
            get
            {
                return HttpContext.Current.Cache["someId"] as ConcurrentDictionary<string, string>;
            }
            set
            {
                HttpContext.Current.Cache["someId"] = value;
            }
    }
