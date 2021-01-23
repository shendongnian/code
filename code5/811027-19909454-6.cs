    public ActionResult RecordBusinesses(FormCollection collection)
    {
        List<Entity> myEntities = ...;
        foreach (var item in collection.GetValues("mycheckboxlist"))
        {
            ...
            myEntities.Add(new ...);
        }
        return View("SomeContainerView", myEntities);
    }
