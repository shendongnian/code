    public ActionResult Index()
        {
            var temp = db.Parents.Where(x=>x.ID==1)
                 .Include(x => x.Childrens).FirstOrDefault();
            return View(temp);
        }
