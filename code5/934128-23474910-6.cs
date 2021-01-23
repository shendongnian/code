    [HttpGet]
    public ActionResult Create()
    {
        var model = new CreateDogModel 
        {
             Humans = db.Human.ToList()
        };
        return View(model);
    }
