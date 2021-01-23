    public ActionResult MethodName(int page=1)
     {
       SQLServerDatabaseEntities entity = new SQLServerDatabaseEntities();
       List<NameOfEntity> models = entity.DBSetPropertyName
                                   .OrderBy(n=>n.PropertyNameFromTheEntity)
                                   .Skip((page - 1) * 10) 
                                   .Take(10).ToList();
           //Add the information about what the method should do.
       return View(models);
     }
