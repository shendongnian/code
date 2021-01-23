    [HttpGet]
    public ActionResult MyControllerAction()
    {
       var myViewModel = new MyViewModel();
       return View(myViewModel);
    }
    [HttpPost]
    public ActionResult MyControllerAction(MyViewModel myViewModel)
    {
      //do whatever you want
    }
