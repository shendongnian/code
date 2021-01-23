    public ActionResult Index()
    {
        return View(L.Tables);
    }
    public ActionResult AddTable()
    {
        L.Tables.Add(new Table(3));
        return RedirectToAction("Index", "Poker");
    }
