     public ViewResult CreateFormModelConfigurarAreaItem()
    {
         DatabaseEntities db=new DatabaseEntities();
         return View("FormModelConfigurarAreaItemRow", new FormModelConfigurarAreaItem{ Agrupaciones =  db.AgrupacionChequeo.toList()});
    }
