    [Authorize(Roles = "Admin")]
    public ActionResult AdminController()
    {
        //Some process 
         return View(); //This returns admin view if user access this controller.
    }
      [Authorize(Users = "someUser")]
      public ActionResult AdminProfile()
      {
        return View();
      }
