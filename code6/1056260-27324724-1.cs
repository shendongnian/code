    [HttpGet]
    public ActionResult Create()
    {
        ServiceForm form = new ServiceForm();
       
        List<SelectListItem> cat = new List<SelectListItem>();
        cat.Add(new SelectListItem { Text = "General", Value = "General", Selected = true });
        cat.Add(new SelectListItem { Text = "Grades", Value = "Grades", Selected = false });
        cat.Add(new SelectListItem { Text = "Time Table", Value = "TimeTable", Selected = false });
        cat.Add(new SelectListItem { Text = "Zenit Account", Value = "Zenit", Selected = false });
        form.Categories = cat; 
        //fill Programs property here...
        return View(form);
    }
