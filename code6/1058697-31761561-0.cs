    private readonly IHostingEnvironment _env;
    public HomeController(IHostingEnvironment env)
    {
        _env = env;
    }
    public IActionResult Index()
    {
       var dataFolderPath = _env.MapPath("APP_DATA");
       return View();
    }
