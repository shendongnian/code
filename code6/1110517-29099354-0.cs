	[Authorize]
	public async Task<JsonResult> ValidatePassword (string newPassword)
	{
		var result = this.DoSomeValidationOfPassword(newPassword);
		if (result.Succeeded)
		{
			return this.Json(true, JsonRequestBehavior.AllowGet);
		}
		else
		{
			return this.Json("The password has the following demands:\r\n" 
                        + string.Join("\r\n", result.Errors), JsonRequestBehavior.AllowGet);
		}
	}
