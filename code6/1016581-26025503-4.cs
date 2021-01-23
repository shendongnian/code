     [HttpPost]
     public ActionResult ProcessLogEntries(...)
     {
         var model = new LogsResearchViewModel();
         // ...
         return Json(model);
     }
