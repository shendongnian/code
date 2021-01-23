    // Injection
    public MyClass(Func<IServiceClient> createServiceClient)
    {
        this.createServiceClient = createServiceClient;
    }
    // Usage
    try
    {
        var client = createServiceClient();
        client.Operation1();
    }
    // Instance creation
    var myClass = new MyClass(() => new ServiceClient());
