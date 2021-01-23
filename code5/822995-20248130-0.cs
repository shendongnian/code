    [HttpGet]
    public override ActionResult Edit(string slug)
    {
        return HttpNotFound();
    }
    
    [HttpGet]
    public ActionResult Edit(string slug, string companySlug)
    {
        // some code...
    }
