     public ActionResult MyPage()
     {
          // security
          if (failCheck)
             return RedirectToAction("NoAccess", "MyController");
          /*
            Do normal code
          */
          // Display page
          return View();
     }
