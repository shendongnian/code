    public void Config(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        config.Formatters.JsonFormatter.SerializerSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
        app.UseWebApi(config);
    }
