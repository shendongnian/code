    [HttpPost]
    public ActionResult Create(Names name)
    {
        var names = name.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
        foreach(var n in names) 
        {
            unitofwork.Names.Insert(n);
        }
        unitofwork.save();
    
        return RedirectToAction("Index");
    }
