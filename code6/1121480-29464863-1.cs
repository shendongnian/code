    public ActionResult Index()
    {
        MyViewModel model = new MyViewModel();
        // other codes here
        // ...
        model.IsRecommended = ....; // logic from cekrecomended method here
        return View(model);
    }
