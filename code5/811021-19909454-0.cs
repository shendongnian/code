    public ActionResult RecordBusinesses(FormCollection collection)
    {
        foreach (var item in collection.GetValues("mycheckboxlist"))
        {
            ...
            return PartialView("_mypartialview", modelentity);
        }
        return PartialView("_mypartialview");
    }
