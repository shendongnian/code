	public ActionResult GetImage(string name)
	{
		return getFileContentResult(name, true);
		// or use the image directly for example in a HTML img tag
		// return getFileContentResult(name);
	}
