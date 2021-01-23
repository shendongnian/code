    // This method will be called for /ControllerName/Index requests
    public ActionResult Index() { ... }
    
    [ActionName("Index2")] // This method will be called for /ControllerName/Index2 requests
    public ActionResult Index(int id) { ... }
