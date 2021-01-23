    // Move the state list to a static / cached initialization
    private static HashSet<string> StateList = new HashSet<string>
    {
        "AL","AK", ...
    };
    // The check for valid state is now a simple lookup in the HashSet
    protected void stateArrayCheck(Object source, ServerValidateEventArgs args)
    {
        args.IsValid = StateList.Contains(valState.Text);
    }
