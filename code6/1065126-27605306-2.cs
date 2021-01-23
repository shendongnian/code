    public static class InfoHelper
    {
        private static Lazy<ConcurrentDictionary<string, string>> infoBuilder
             = new Lazy<ConcurrentDictionary<string, string>>( () => SomeCreationMethod() );
        public static ConcurrentDictionary<string, string> Info
        {
            get
            {
                return infoBuilder.Value;
            }
    }
