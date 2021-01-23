    private Entities en = new Entities(); 
    
            public ActionResult Index(string selectedvalue)
                    {
                        
        List<SelectListItem> selectlist = 
        en.tblUser.Select(x => new SelectListItem { Text = x.Name, Value = x.Id, 
    
        Selected = ( x.Name == selectedvalue ? false : true) })
        .ToList();
                        ViewBag.DropDown = selectlist;
                        return View();
                    }
