    public bool TryExecuteCommand(string input)
    {
        if (!CanGetArgumentsFrom(input))
            return false;
        Execute();
        return true;
    }
