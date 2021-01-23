	[AllowAnonymous]
	public ActionResult ActionAvailableToEveryone()
	{
		if (!User.Identity.IsAuthenticated)
		{
			return new HttpUnauthorizedResult();
		}
		return View();
	}
