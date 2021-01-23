    public partial class Startup
    {
        public static IDataProtectionProvider DataProtectionProvider 
        { 
            get; 
            private set; 
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            DataProtectionProvider = 
                new DpapiDataProtectionProvider("WebApp2015");
            // other code removed
        }
    }
