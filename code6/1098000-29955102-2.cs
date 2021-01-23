	[AllowAnonymous]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> ExternalLinkLogin(string provider) //Google,Twitter etc.
	{
		return new ChallengeResult(provider, Url.Action("ExternalLinkLoginCallback"), userId);
	}
	[AllowAnonymous]
	[HttpGet]        
	public async Task<ActionResult> ExternalLinkLoginCallback()
	{
		// Handle external Login Callback
		var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey,userId);
		if (loginInfo == null)
		{
			IdentitySignout(); // to be safe we log out
			return RedirectToAction("Register", new {message = "Unable to authenticate with external login."});
		}
		...
		
		IdentitySignIn(userId, userName, returnUrl);
	}
