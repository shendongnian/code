    private void ConfigureWebApi(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
        var container = new UnityContainer();
        container.RegisterType<IPayPalValidator, PayPalValidator>();
        config.DependencyResolver = new UnityDependencyResolver(container);
        var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter().First();
        jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
