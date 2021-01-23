    public ActionResult Index()
    {
        return View(L.Tables);
    }
    public void AddTables()
    {
        L.Tables.Add(new Tables(3));
        L.SaveToDB(); // just an example
        RedirectToAction("Index");
    }
