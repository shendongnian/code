     MyDbContext _db = new MyDbContext();
    public ActionResult ArticleList()
            {
                var vm = _db.Articles.ToList();
                return PartialView("_CartListing", vm);
            }
            
            [HttpPost]
            public ActionResult DeleteArticle(int Id)
            {
                var a = _db.Articles.Find(Id);
                _db.Articles.Remove(a);
                _db.SaveChanges();
    
                var vm = _db.Articles.ToList();
                return PartialView("_CartListing", vm);
            }
