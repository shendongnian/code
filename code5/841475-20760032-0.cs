    [HttpPost]
    public ActionResult Admin_Mgmt(List<thing> things, int Action_Code)
     {
          switch (Action_Code)
          {
              case 1: 
                 {   
                        TempData["Things"] = things; 
                        // OR 
                        ViewBag.Things = things;
                        // OR 
                        ViewData["Things"] = things;
                        //redirecting requesting to another controller 
                        return RedirectToAction("Quran_Loading", "Request_Handler");
                 }
               default:
                       ...
            }
        }
