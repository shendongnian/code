    [HttpPost]
    public ActionResult Index(MyModel model)
    {
       if(ModelState.IsValid)
       {
         // Save and redirect
       }
       //reload the collection again and return the model to the view
       model.nameList=getNames();
       return View(model); 
    }
