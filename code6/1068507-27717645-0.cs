    public ActionResult Create(CreateViewModel adds)
        {
            if (ModelState.IsValid)
            {
                Add add = new Add();
                ------
    
       List<SelectListItem> list = new List<SelectListItem>() {
         new SelectListItem(){ Value="1", Text="Bohuslän"},
         new SelectListItem(){ Value="2", Text="Dalarna"},
         new SelectListItem(){ Value="3", Text="Dalsland"}
                                                            };
       SelectList surbs = new SelectList(list, "Value", "Text");
       ViewBag.Dropdown = surbs;
       return View();
