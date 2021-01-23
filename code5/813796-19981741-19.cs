    private UnitOfWork _uow;
    public UserController(UnitOfWork uow)
    {
        _uow = uow;
        _us = new UserService(_uow);
    }
    public ActionResult SentMessages()
    {
       return View(us.GetSentMessages());     
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            _uow.Dispose();
        base.Dispose(disposing);
    }
    
   
