    public ActionResult DetailsReport()
    {
         var model = new ReportModel();
         model.StartDate = DateTime.Now;
         model.StartEnd = DateTime.Now;
	     return View(model);
    }
