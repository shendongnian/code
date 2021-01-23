	[Authorize]
	public async Task<JsonResult> ValidatePassword (string NewPassword)
	{
        var result = await this.DoSomeValidationOfPassword(NewPassword);
		if (result)
		{
			return this.Json(true, JsonRequestBehavior.AllowGet);
		}
		else
		{
			return this.Json("The password has the following demands:\r\n" 
                        + string.Join("\r\n", result.Errors), JsonRequestBehavior.AllowGet);
		}
	}
