    public ActionResult Create()
    {
            ViewBag.GradingId = new SelectList(db.Gradings, "GradingId", "CodeName");
            return View();
    }
