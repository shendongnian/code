    public JsonResult GetModuls()
    {   
       var model = BLcontext.GetModuls();      
       return Json(new { data = model }, JsonRequestBehavior.AllowGet);                       
    }
