    public ActionResult Index(string sortOrder)
    {
        ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
        // Rest of your sortOrder param goes here...
    
        var persons = from s in db.PRT_FEE_PRICES
                      select s;
        switch (sortOrder)
        {
            case "name":
                if(sortOrder.Equals(CurrentSort))
            persons = persons.OrderBy(s => s.NAME);
               else
             persons = persons.OrderByDescending(s => s.NAME);
                break;
            `enter code here` // ...
        }
    
        return View(persons.ToList());
    }
