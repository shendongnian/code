    public ActionResult CreateMyModels()
    {
        var myModels = new List<MyModel>();
        for (var i = 0; i < totalItems; i++)
        {
            myModels.Add(new MyModel());
        }
        return View(myModels)
    }
