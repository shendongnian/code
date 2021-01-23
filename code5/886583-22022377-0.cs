    public string LicenseDate { get; set; }
    public string CurrentDate = DateTime.Now.ToString("dd-MM-yyyy");
    
    public ActionResult Index() {
       var licenseDateTime = Convert.ToDateTime(LicenseDate);
       if ((licenseDateTime.Subtract(DateTime.Today)).TotalDays > 1)
       {
           // do something
       } else {
           return RedirectToAction("../Home/Buy");
       }
    }
