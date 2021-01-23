    using PagedList;
    public ActionResult Index(int ? pagePos)
    {
            //var itemList = db.Items.ToList();
            int pageNumber = (pagePos ?? 1);
            return View(db.Items.ToList().ToPagedList(pageNumber, 30));
    }
