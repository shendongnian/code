    public void SomeTestMethod()
    {
        var worker = new Worker(CreateMockService);
    }
    private IService CreateMockService(int arg)
    {
        return new Mock(arg);
    }
