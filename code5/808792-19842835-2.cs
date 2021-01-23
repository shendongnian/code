    public ActionResult Result(string text)
    {
        var model = new Search { searchCriteria = text };
        return View(model);
    }
