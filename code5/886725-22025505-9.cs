    IYourRepository _repository;
    public YourController(IYourRepository repository)
    {
        _repository = repository;
    }
    
    public ActionResult Index()
    {
        var model = new myModel();
        foreach (var p in _repository.FetchPData())
            // do stuff
        foreach (var s in _repository.FetchSData())
            // do stuff
        
        return View("Index", model);
    }
