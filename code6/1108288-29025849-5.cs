    public ActionResult Index()
    {
        var model = new ExampleModel 
            { 
                WelcomeMessage = _myClass.Translate("Welcome") 
            };
        return View(model);
    }
