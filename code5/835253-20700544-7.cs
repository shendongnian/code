    public ActionResult Index()
    {
        Test test = new Test();
        test.Name = "XYZ";
        string html = RazorViewToString.RenderRazorViewToString(this, "~/Views/Test/index.cshtml", test);
        return View();
    }
