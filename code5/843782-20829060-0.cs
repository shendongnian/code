    // Without Automapper
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ItemDetailViewModel model)
    {
        if (ModelState.IsValid)
        {
            var item = new Item() 
            {
                Active = model.Active,
                ItemCode = model.ItemCode,
                Name = model.Name,
                ItemOptions = // code to convert from List<ItemDetailItemOptionViewModel> to List<ItemOption>
            }
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(model);
    }
    
    
    // with Automapper - not recommended by author of Automapper
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ItemDetailViewModel model)
    {
        if (ModelState.IsValid)
        {
            var item = Automapper.Mapper.Map<Item>(model);
            
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(model);
    }    
