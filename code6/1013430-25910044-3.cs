    public void Configuration(IAppBuilder app)
    {
    	ConfigureOAuth(app);
    
    	HttpConfiguration config = new HttpConfiguration();
    	WebApiConfig.Register(config);
    	config.Filters.Add(new MyAuthorizeAttribute());
    }
