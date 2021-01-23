    IYourRepository _repository;
    public YourController(IYourRepository repository)
    {
        _repository = repository;
    }
    
    public ActionResult Index()
    {
        foreach (var p in _repository.FetchPData())
            // ...
        foreach (var s in _repository.FetchSData())
            // ...
        // do stuff
    }
