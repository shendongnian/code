    public ActionResult Sales(){
       var model = new SalesFilter();
       model.FilteredValues = db.YourSales.Where(/*your init conditions*/);
       //set other initial values in your ViewModel
    
       return View(model);
    }
    [HttpPost]
    public ActionResult Sales(SalesFilter filters){
       model.FilteredValues = db.YourSales.Where(/*use the conditions of your filter */);
       
    model.TypesOfSales = new SelectList(db.TypesOfSales, "idType", "Name", filter.IdTypeOfSale);
    
       return View(model);
    }
