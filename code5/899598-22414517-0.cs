    [HttpGet]
    public ActionResult Index()
    {
        if( TempData.ContainsKey( "DisplayGrid" )
            myModel.DisplayGrid = (bool)TempData["DisplayGrid"];
    }
    [HttpPost]
    public ActionResult Index( string dropDownValues, string criteria, string days )
    {
        // Do stuff
        TempData["DisplayGrid"] = true;
        return RedirectToAction( "Index" );
    }
