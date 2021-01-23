	public ActionResult MyPage(string parameter)
	{
		var parameterValue = MyUrls.Url1;
		if (!string.IsNullOrEmpty(parameter) && !Enum.TryParse(parameter, out parameterValue))
			return HttpNotFound();
		return View("MyView");
	}
