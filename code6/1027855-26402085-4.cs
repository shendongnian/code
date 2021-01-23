    protected void OnRepeaterCommand(object source, RepeaterCommandEventArgs e)
    {
        source.GetType()
        .GetMethod("RaiseBubbleEvent", BindingFlags.NonPublic | BindingFlags.Instance)
		.Invoke(source, new[]
		{
			e.CommandSource,
			new CommandEventArgs(e.CommandName, e.CommandArgument)
		});
    }
