    [HttpPost]
    [GridAction]
    public ActionResult UpdateAction([Bind(Prefix = "updated")]IEnumerable<YourViewModel> updatedTransactions)
    {
    ...
    }
    
    [HttpPost]
    [GridAction]
    public ActionResult InsertAction([Bind(Prefix = "inserted")]IEnumerable<YourViewModel> insertedTransactions)
    {
    ...
    }
    
    [HttpPost]
    [GridAction]
    public ActionResult DeleteAction([Bind(Prefix = "deleted")]IEnumerable<YourViewModel> deletedTransactions)
    {
    ...
    }
