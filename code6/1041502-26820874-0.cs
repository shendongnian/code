     public ActionResult Index()
            {
                var products = db.products.Include(p => p.category).Include(p => p.promotion).Include(p => p.user);
                ViewBag.Count = utOfW.ProductRepository.GetById(1).pictures.Count(); // the result is 3 and it is true 
    
                return View(products.ToList());
            }
