    case SignInStatus.Success:
    	if (!await UserManager.IsEmailConfirmedAsync((await UserManager.FindByNameAsync(model.Email)).Id))
    	{
            Session.Abandon();
    		AuthenticationManager.SignOut();
    		ModelState.AddModelError("", "You need to confirm your email address");
    		return View(model);
    	}
    	return RedirectToLocal(returnUrl);
