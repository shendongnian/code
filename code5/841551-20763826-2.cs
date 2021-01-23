    //
    // POST: /Account/Register
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(CreateAccountViewModel model)
    {
    	if (ModelState.IsValid) {
    		Customer customer = Mapper.Map<Customer>(model.Customer);
    		var user = new ApplicationUser() { UserName = model.UserName, Customer = customer };
    
    		var result = UserManager.Create(user, model.Password);
    		if (result.Succeeded)
    		{
    			await SignInAsync(user, false);
    			return RedirectToAction("Index", "Home");
    		}
    		else
    		{
    			AddErrors(result);
    		}
    	}
    
    	// If we got this far, something failed, redisplay form
    	return View(model);
    }
