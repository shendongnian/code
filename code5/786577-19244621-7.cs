    [HttpPost]
    public ActionResult ImportCalculationSheet(ImportCalculationSheetModel model)
    {
        var m = new ImportCalculationSheetModel { 
            FailedProductIdsList = new List<string> { "test1", "test2", "test3" } 
        };
        if (ModelState.IsValid)
        {
            return View("ViewName", m);
        }
    }
