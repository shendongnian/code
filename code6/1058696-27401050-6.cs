    private readonly IHostingEnvironment _hostingEnvironment;
    public HomeController(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    
    public IActionResult Index()
    {
       var rootPath = _hostingEnvironment.MapPath("APP_DATA");
       return View();
    }
