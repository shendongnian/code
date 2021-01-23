    public ActionResult YourAction()
    {
      bool isAllowed = User.IsInRole("Manager")||User.IsInRole("Salesperson");
      ViewBag.isAllowed = isAllowed;
    
      ...
      return View();
    }
