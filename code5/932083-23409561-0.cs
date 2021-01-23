    private readonly ExternalServiceClient _serviceClient;
    public MyService(IExternalServiceClient serviceClient)
    {
        _serviceClient = serviceClient;
    }
