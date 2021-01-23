    [HttpGet]
    public ActionResult Login()
    {
        ViewBag.Companies = (from a in _context.Companies 
                         select new {Key = a.Id, Value = a.Name});
        // get your Company 
        var cmp = _context.Companies.First(); //for example
        return View(cmp);
    }
