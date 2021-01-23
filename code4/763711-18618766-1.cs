    public ActionResult Index()
    {
      var clients = DBLogic.GetAllClient()
    
      return View(clients);
    }
