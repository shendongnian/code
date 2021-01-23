    public override void Configure(Container container)
    {
        //...
       Plugins.Add(new RazorFormat());
       Plugins.Add(new SwaggerFeature());
       //...
    }
