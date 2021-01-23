    public ActionResult Index(int? pId)
    {
        using (u = new UnitOfWork())
        {   
            var z = pId.HasValue 
                ? u.CategoryRepository.GetByAll(q => q.ParrentId == pId)
                : u.CategoryRepository.GetByAll();
    
            return View(z);
        }            
    }
