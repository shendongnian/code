    public ActionResult Index(string sortOrder)
    {
        ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
        // Rest of your sortOrder param goes here...
        var persons = from s in db.PRT_FEE_PRICES
                      select s;
        switch (sortOrder)
        {
            case "name":
                persons = persons.OrderBy(s => s.NAME);
                break;
            case "name_desc":
                persons = persons.OrderByDescending(s => s.NAME);
                break;
            // ...
        }
        return View(persons.ToList());
    }
