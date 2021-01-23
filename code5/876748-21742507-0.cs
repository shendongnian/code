    [HttpGet, Route("menu/{categoryName}/{subCategoryName}/{productName}")]
    public ActionResult Menu(string categoryName, string subCategoryName,
        string productName)
    {
        ...
    }
