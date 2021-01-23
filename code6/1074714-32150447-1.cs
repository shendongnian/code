    public void Configuration(IAppBuilder app)
    {
        ConfigureOAuth(app);
        var config = new HttpConfiguration();
        WebApiConfig.Register(config);
        app.UseWebApi(config);
    }
