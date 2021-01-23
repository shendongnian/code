    [HttpPost]
    public ActionResult SaveOfficeConfiguration(int ? officeID, FormCollection form) 
    {
    var CheckBoxValues = form["KCCM_Brands"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x));
    }
