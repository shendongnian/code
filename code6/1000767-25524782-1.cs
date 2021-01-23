    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ManageAccount(string name)
    {
       
        var user = UserRepository.GetById(WebUserSecurity.CurrentUserId);
        var model = Mapper.Map<Customer, ManageViewModel>(user);
        // model updates:    
        model.Name = name;
        //validation checks...
        if (String.IsNullOrEmpty(model.Name)) {
           //add model error
        }
        if (!ModelState.IsValid)
        {
         return View(model);
        }
        // save changes...
    
        return View(model);
    }
