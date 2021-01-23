    public ActionResult Index(string filterTerm = "")
     {
            var stuff= m_repo.GetAllStuff();
            if (stuff.IsNullOrEmpty())
            {
                return View();
            }
    
            if (!string.IsNullOrEmpty(filterTerm))
            {
                stuff= stuff.Where(t => t.Name.Contains(filterTerm));
            }
    
            return View(stuff.ToList());
     }
