    public ActionResult Suggest(string term)
    {
        // TODO: use the term here to query your data source
        // and return the suggested results as JSON:
        var results = new[]
        {
            new { id = "1", label = "label 1", value = "value 1" },
            new { id = "2", label = "label 2", value = "value 2" },
            new { id = "3", label = "label 3", value = "value 3" },
        };
        return Json(results, JsonRequestBehavior.AllowGet);
    }
