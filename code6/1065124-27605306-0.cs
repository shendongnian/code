    public static class InfoHelper
    {
        private static Lazy<Dictionary<string, string>> infoBuilder
             = new Lazy<Dictionary<string, string>>( () => SomeCreationMethod() );
        public static Dictionary<string, string> Info
        {
            get
            {
                return infoBuilder.Value;
            }
    }
