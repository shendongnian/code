    if (!ModelState.IsValid)
    {
    	if (ModelState["."].Errors.Any())
    	{
    		ModelState.AddModelError(string.Empty, ModelState["."].Errors.First().ErrorMessage);
    	}
    	// ...
    }
