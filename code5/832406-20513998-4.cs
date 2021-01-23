    protected void Alert(string message)
	{
                // Check to see if it exists already and removes it
		if (TempData.ContainsKey("warning"))
			TempData.Remove("warning");
		TempData.Add("warning", message);
	}
