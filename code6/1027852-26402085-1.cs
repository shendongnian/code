    protected void OnRepeaterCommand(object source, RepeaterCommandEventArgs e)
    {
        var repeater = (Repeater)source;
        var raiseBubbleEvent = repeater.GetType().GetMethod("RaiseBubbleEvent", BindingFlags.NonPublic | BindingFlags.Instance);
        raiseBubbleEvent.Invoke(repeater, new[] { e.CommandSource, new CommandEventArgs(e.CommandName, e.CommandArgument) });
    }
