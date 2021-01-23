    [HttpPost]
    public ActionResult Refresh(int id)
    {
        try
        {
            HomeViewModel model = new HomeViewModel();
            model.id = id;
            
            ViewBag.id = model.id;
            PrepareModel(ref model);
            return PartialView("~/Views/PartialView.cshtml", model);
        }
        catch
        {
            return Content("error");
        }
    }
