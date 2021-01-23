    public ActionResult Empty(string lastAction, string lastController)
    {
    var vm = new NavigationVM()
    {
    LastAction = lastAction,
    LastController = lastController
    }
    return View(vm);
    }
