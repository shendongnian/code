    IContainer container = new Container(x =>
    {
        x.AddRegistry<DatabaseRegistry>();
        x.AddRegistry<WebsiteRegistry>();
    });
