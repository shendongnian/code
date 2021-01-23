    [HttpPost]
    public ActionResult Index(string File)
    {
        // Some validation logic
        return RedirectToAction("ShowList", new { protocol = File });
    }
    public ActionResult ShowList(string protocol)
    {
        var list = db.MyObjects.Where(x => x.protocol == protocol).ToArray();
        ViewBag.Files = list;
        return View();
    }
