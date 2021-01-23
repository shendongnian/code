    public static void Register(HttpConfiguration config)
    {
        config.Formatters.Clear();
        config.Formatters.Add(new JsonMediaTypeFormatter());
        config.Formatters.Add(new XmlMediaTypeFormatter());   
    }
