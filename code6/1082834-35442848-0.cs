    [HttpGet]
    [Route("MyApiMethod", Name = "MyApiMethod")]
    public MyApiMethod PropertyData(...)
    {
        ...
    }
    // ERROR: Causes "System.ArgumentException: A route named 'DefaultRoute' is already in the route collection. Route names must be unique."
    [HttpPost]
    [Route("MyApiMethod", Name = "MyApiMethod")]
    public MyApiMethod PropertyData(...)
    {
        ...
    }
