    [HttpGet]
    public ActionResult Create()
    {
        var vm = new QuestionnaireViewModel();
        vm.QuestionnaireUID = Guid.NewGuid();
        vm.UserUID = Guid.NewGuid();
        return View(vm);
    }
