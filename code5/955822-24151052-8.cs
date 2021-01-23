    public ActionResult Create()
    {
        var model = db.Cupcakes.Select(c => new CupcakeViewModel {
                                                    Id = c.Id,
                                                    Name = c.Name,
                                                    Quantity = 0 
                               })
                               .ToList();
    
        return View(model);
    }
    [HttpPost]
    public ActionResult Create(CupcakeViewModel[] cakes)
    {
         //Save choosen cakes
    }
