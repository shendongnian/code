    public class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            ...
    
    		HttpConfiguration config = new HttpConfiguration();
    
            WebApiConfig.Register(config);
            config.Filters.Add(new WebApiAuthorizeAttribute());
            
            ...
    
        }
    ...
    }
