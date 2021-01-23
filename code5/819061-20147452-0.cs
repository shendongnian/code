    private T Get()
    {
       int id = 5;
       return GetInternal(id);
    }
    [Cache]
    private T GetInternal(int id)
    {
       return GetCustomerService(id);
    }
