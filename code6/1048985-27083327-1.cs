    [MvcSiteMapNode(Title = "Article 1", ParentKey = "News", Attributes = @"{ ""id"": 1 }")]
    [MvcSiteMapNode(Title = "Article 2", ParentKey = "News", Attributes = @"{ ""id"": 2 }")]
    [MvcSiteMapNode(Title = "Article 3", ParentKey = "News", Attributes = @"{ ""id"": 3 }")]
    public ActionResult News(int id)
    {
        ViewBag.id = id;
        return View();
    }
