    public ActionResult Index()
    {
        IList<string> strings = new List<string>();
        strings.Add("Python");
        strings.Add("C#");
        strings.Add("Javascript");
        strings.Add("Ruby");
        return View(strings);
    }
