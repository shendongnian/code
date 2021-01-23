    // Injection
    public MyClass(IServiceClientFactory serviceClientFactory)
    {
        this.serviceClientFactory = serviceClientFactory;
    }
    // Usage
    try
    {
        var client = serviceClientFactory.CreateInstance();
        client.Operation1();
    }
