    public ActionResult CreateNewFunctionNavigation(CreateFunctionNavigation_SP_Map obj)
    {
      if (!ModelState.IsValid) 
      {
        return View(obj);
      }
    // rest of method here
