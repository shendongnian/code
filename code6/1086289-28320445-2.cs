    public ActionResult Create(){
    var model = new ViewModel();
    
    model.Asset = new Asset();
    model.Asset.Categories = new List<Categories>();
    
    return View(model);
    }
