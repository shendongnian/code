	[HttpPost]
	public async Task<IHttpActionResult> TestAction([FromODataUri] int key, ODataActionParameters parameters)
	{
		// Do your thing here..
		var invites = parameters["ArrayHere"] as IEnumerable<string>;
	}
