    [HttpPost]
    public ActionResult Index(string value)
    {
        List<string> ll = new List<string>();
        ll.Add("kkk");
        ll.Add("qq");
        ll.Add("aa");
        ll.Add("zz");
        return PartialView("_List", ll);
    }
