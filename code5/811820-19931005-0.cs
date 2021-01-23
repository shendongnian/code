    public static class GlobalConfiguration
    {
        static GlobalConfiguration()
        {
            Objects = new Dictionary<string, object>();
        }
        public readonly IDictionary<string, object> Objects { get; set; }
    }
