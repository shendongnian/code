    private static IMyRepository _instance;
    public IMyRepository Repository
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new SomeRepositoryObject();
            }
            return _instance
        }
    }
