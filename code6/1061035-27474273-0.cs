    public class AuthConfig
    {
        public static IDataProtectionProvider DataProtectionProvider { get; set; }
    
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    
        public void ConfigureAuth(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();
    
            // do other configuration 
        }
    }
