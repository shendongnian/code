    // Setup definition node as a .NET Attribute (won't be in the SiteMap)
    // Any properties you put here will be the defaults in the dynamic node provider, but can be overridden there.
    [MvcSiteMapNode(DynamicNodeProvider = "MyNamespace.NewsDynamicNodeProvider, MyAssembly")]
    public ActionResult News(int id)
    {
        ViewBag.id = id;
        return View();
    }
