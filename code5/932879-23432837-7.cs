    [HttpGet]
    public ActionResult MyControllerAction()
    {
       var myViewModel = new MyViewModel();
       return View(myViewModel);
    }
