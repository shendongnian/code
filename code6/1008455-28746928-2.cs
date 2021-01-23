    public void Configuration(IAppBuilder app)
    {
            var properties = new Dictionary<string, object>();
            properties.Add("AppName", AppName);
            //pass any properties through the Owin context Environment
            app.Use(typeof(PropertiesMiddleware), new object[] { properties });
    }
