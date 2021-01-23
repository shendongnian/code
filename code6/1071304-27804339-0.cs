    public ActionResult EcgBilling()
    {
        var model = new SelectBillingSiteReportModel
        {
            Sites = new List<SelectListItem>
            {
                new SelectListItem {Text = "One", Value = "One:1"},
                new SelectListItem {Text = "Two", Value = "Two:2"},
                new SelectListItem {Text = "Three", Value = "Three:3"},
            }
        };
        return View(model);
    }
    
    [HttpPost]
    public ActionResult EcgBilling(SelectBillingSiteReportModel model)
    {
        string[] array = model.SelectedSiteKey.Split(':');
        string text = array[0];
        string value = array[1];
        return View();
    }
