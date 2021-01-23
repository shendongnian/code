    public OptionsParser(IRequestHandlerFactory factory)
    {
        var test = factory.CreateGeneric<GetEngineOptionsRequest, GetEngineOptionsResult>();
        var test2 = factory.CreateSpecific();
    }
