    public ActionResult Index()
    {
        var uid = HttpContext.Current.Request.Headers["uid"];
        // Add your view model logic here...
        var model = new TestModel
        {
            HeaderValue = uid
        };
        return View(model);
    }
