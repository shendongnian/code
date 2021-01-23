    public ActionResult Index()
    {
        var result = this.queryHandler.ValidatedHandle(this.ModelState, new SomeQuery { });
        if (result.IsValid) {
            return this.View(new HomeViewModel(result.Data));
        }
        else
        {
            return this.View(new HomeViewModel());
        }
    }
