     public ActionResult Search()
            {   
    
                SearchPageModel spm = new SearchPageModel();       
    
                spm.DistrictTypesList = spm.populateDistrictTypeDropDown();
    
                return View(spm);
            }
