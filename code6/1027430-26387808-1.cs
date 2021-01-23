    [MvcSiteMapNode(DynamicNodeProvider = "MyNamespace.BlogDynamicNodeProvider, MyAssembly", Route = "Blog")]
    public ActionResult ViewBlog(int id, string seoName)
    {
        // Retrieve your blog post here...
        return View();
    }
