    public HttpResponseMessage Get(int id)
    {
        var foo = new Foo() { Id = id };
        return new HttpResponseMessage()
        {
            Content = new ObjectContent<Foo>(foo,
                      Configuration.Formatters.JsonFormatter)
        };
    }
