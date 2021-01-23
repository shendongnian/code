    public ActionResult MyAction(...parameters...)
    {
 
        // ... same as above ...
        // Create a StaticPagedList
        StaticPagedList<MyObjectViewModel> staticPagedList = new StaticPagedList<MyObjectViewModel>(myVMList , pageNumber + 1, pageSize, myObjs.Count());
        // Return a View with the StaticPagedList
        return View(myStaticPagedList);
    }
