    [HttpPost]
    public ActionResult Generate(PlanDetailsVM planDetailsVM) 
    {
       System.Diagnostics.Debug.WriteLine("controller 1");
                   
       HostingEnvironment.QueueBackgroundWorkItem(ct => _planDesignBS.GenerateBS(planDetailsVM));
       System.Diagnostics.Debug.WriteLine("controller 2");
       return Json(quoteId , JsonRequestBehavior.AllowGet);
    }
