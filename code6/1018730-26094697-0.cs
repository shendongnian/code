     public ActionResult Create([Bind(Include = "Title,Body,SubTitle")]News model){
      if (ModelState.IsValid){
        ApplicationDbContext.News.Add(model);
        ApplicationDbContext.News.SaveChanges();
    
      }
    }
