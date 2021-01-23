     public ActionResult Index(int page = 1)
        {
            //_db is my sample data context but paged list works for any IEnumerable
            //since this is an extension method
            var model = 
                _db.Comments
                .OrderByDescending(c => c.Date)
                .ToPagedList(page, 10);
            
            return View(model);
        }
