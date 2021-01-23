    public ActionResult Create(){
           ViewBag.Names= new SelectList(db.TbName, "ID", "MidName");
           return View();
        }
    [HttpPost]
    public ActionResult Create(){
           ViewBag.Names= new SelectList(db.TbName, "ID", "MidName");
           return View();
        }
