    private readonly IViewModelFactory _factory;
    public HomeController(IViewModelFactory factory)
    {
        _factory = factory;
        var model = _factory.GetViewModelInstance(); 
        // Where Services is a property of the Controller
    } 
