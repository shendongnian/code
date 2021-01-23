     public ActionResult OtherDataPage()
     {
        LandingPageViewModel model = new LandingPageViewModel();
        model = TempData["Model"];
        return View();
     }
