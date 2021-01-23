    public ActionResult YourAction(int treatmentId)
    {
    
    List<SelectListItem> list = new List<SelectListItem>();
    
    list.Add(new SelectListItem {Text = "9:00", Value = "1"})
    
    return PartialView("PartialViewDropDownSchedule",list);
    
    }
