    public ActionResult ViewQuery() 
    {       
        DBController dBController = new DBController();     
        ViewBag.JsonData= dBController.GetXXX(); 
        return Json(dBController.usp_CIOChallenge_Admin_view_query(), JsonRequestBehavior.AllowGet);
    }
  
