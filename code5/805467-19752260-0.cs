    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
         foreach ( string key in collection.AllKeys )
         {
              ViewData[key] = collection[key];   
         }
    
         return View()
    
    }
