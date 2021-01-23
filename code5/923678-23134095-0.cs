    public virtual ActionResult Index()
    {
        return View(new HomepageModel()
        {
                Strings = new[] {"one", "two", "three"}
        });
    }
    [HttpPost]
    public ActionResult Index(List<string> strings)
    {
        throw new Exception(String.Join(", ", strings));
    }
