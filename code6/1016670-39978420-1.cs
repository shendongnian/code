    protected void Application_Start()
    {
        //...
        GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger), new NewRelicExceptionLogger());
    }
