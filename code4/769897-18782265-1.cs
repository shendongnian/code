    public ActionResult Create()
    {    
        var model = new SinglePest();
    
        model.Pests = Enum.GetValues(typeof(PestType)).Cast<PestType>()
    
        return View(model);
    }
