    @model Maintenance_.Models.IndexModel
    @{    
        ViewBag.Title = "Technician";
        if(Model.setEnable==true)
        {
            ViewBag.disableUpdate = "";
        }
        else{
            ViewBag.disableUpdate = "disabled";
        }
    }
     
    //HTML codes goes here..
 
