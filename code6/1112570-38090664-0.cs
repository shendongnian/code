    [HttpGet]
    public ActionResult Index()
    {
        List<Contact> model = new List<Contact>();
        using (MyDatabaseEntities dc = new MyDatabaseEntities())
        {
            model = dc.Contacts.ToList();
        }
        return View(model);
    }
