    using PagedList;
    public ActionResult Index(int ? pagePos)
    {
            //return View(db.Items.ToList());// Change this as following
            int pageNumber = (pagePos ?? 1);
            return View(db.Items.ToList().ToPagedList(pageNumber, 30));
            //30 equels number of items per page
    }
