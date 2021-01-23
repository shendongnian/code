    [httpPost]
     public ActionResult Welcome(ModelClass modelClass)
        {
           if(ModelState.isValid)
           {
                 // operation on your data 
           }
            return View(model);
        }
