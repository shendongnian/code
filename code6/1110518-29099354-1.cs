	[Authorize]
	public async Task<JsonResult> ValidatePassword (string NewPassword)
	{
        // this is expected to return IEnumerable<ValidationResult> in this example
		var result = this.DoSomeValidationOfPassword(NewPassword);
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
