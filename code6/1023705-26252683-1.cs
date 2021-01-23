     [Authorize]
            public ActionResult Index()
            {
                return View(db.Traders.ToList());
            }
    
            [HttpPost]
            public ActionResult Index(string searchString)
            {
    
                var traders = from m in db.Traders
                           select m;
    
                if (!String.IsNullOrEmpty(searchString))
                {
                    traders = traders.Where(s => s.Name.Contains(searchString));
                }
    
                return View(traders);
            }
