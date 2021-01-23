        public void PopulateDropDownList(){
    
    var items = Session["MyDropDown"] != null ? (SelectList)Session["MyDropDown"] : null;
    if(items ! null) {ViewBag.StudentCLassList; return;}
    
            items = new SelectList(DB.StudentClasses
                           .Select(sc => new ViewModelClass 
                           { 
                               ID = sc.ID, 
                               ClassName = sc.ClassName 
                           }).ToList(), "ID", "ClassName"); 
    
    Session["MyDropDown"] = ViewBag.StudentCLassList = items;
        
        }
