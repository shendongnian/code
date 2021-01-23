    public ActionResult GetStuff()
    {
       MYPAGENAMEViewModel myViewModel = new MYPAGENAMEViewModel();
       myViewModel.MyTypes = from m in db.ABCs
                           select m.Type.Distinct();
       myViewModel.MyOtherTypes = from m in db.CBAs
                                  select m.Type.Distinct();
       return View(myViewModel); 
    }
