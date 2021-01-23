    [HttpGet]
    public ActionResult Index()
    {
        if( TempData.ContainsKey( "DisplayGrid" )
        {
            // Use the other values from TempData to populate the model with the grid data
            myModel.DisplayGrid = (bool)TempData["DisplayGrid"];
        }
    }
    [HttpPost]
    public ActionResult Index( string dropDownValues, string criteria, string days )
    {
        TempData["DisplayGrid"] = true;
        TempData["DropDownValues"] = dropDownValues;
        TempData["Criteria"] = criteria;
        TempData["Days"] = days;
        return RedirectToAction( "Index" );
    }
