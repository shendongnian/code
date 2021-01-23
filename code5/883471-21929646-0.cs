    public ActionResult Index()
    {
        try
        {
            ViewBag.PersonList = Helper.LoadPersonData();
            if (ViewBag.PersonList == null)
            {
                ViewBag.PersonList = new List<SelectListItem>() 
                { 
                     new SelecListItem()
                     {
                          Value = "nodata", 
                          Text = "No Data" 
                     }
                };
            }
        }
        catch (Exception ex)
        {
            TempData["Message"] = string.Format("An error occurred. Details: {0}", ex.Message);
        }
        return View(persons);
    }
