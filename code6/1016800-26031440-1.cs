	private Dictionary<string, ActionCase> cases = new Dictionary<string, ActionCase>
	{
		{
			"Origin",
			new ActionCase
			{
				ExpectedAction = "Input",
				Test = locator => origin_input(locator, "MEL")
			}
		},
		//Define the rest here
	};
