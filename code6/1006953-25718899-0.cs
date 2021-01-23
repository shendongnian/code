    public ActionResult Create(FormCollection formCollection)
    {
       foreach (var key in formCollection.Keys)
       {
           var value = formCollection[key.ToString()];
           // save value
       }
       return RedirectToAction("Create", "Score");
    }
