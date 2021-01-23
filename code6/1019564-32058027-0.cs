    public async Task<ActionResult> SomeAction(SomeModel model)
    {
	int id = (int)HttpContext.Current.Session["Id"];
	
	/* Session Exists Here */
	var somethingElseAsyncModel = await GetSomethingElseAsync(model);
	/* Session is Null Here */
	// Do something with id, thanks to the fact we got it when we could
    }
