    public HttpResponseMessage Get(int id)
    {
        Foo foo = new Foo();
        var content = new ObjectContent<Foo>(foo,
                        ((id == 1) ? Configuration.Formatters.XmlFormatter :
                                    Configuration.Formatters.JsonFormatter));
        return new HttpResponseMessage()
        {
             Content = content
        };
    }
