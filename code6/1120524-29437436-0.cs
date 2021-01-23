	public override int? OverrideAfterHandlingArgumentsBeforeRun (string[] remainingArguments)
    {
        if (remainingArguments.Length != 2)
        {
            throw new ConsoleAsHelpException("You are expected to enter two numbers.");
        }
        else
        {
            Argument1 = Convert.ToInt32(remainingArguments[0]);
            Argument2 = Convert.ToInt32(remainingArguments[1]);
        }
		return base.OverrideAfterHandlingArgumentsBeforeRun (remainingArguments);
	}
    public override Run((string[] remainingArguments)
    {
        c = Argument1 * Argument2;
        Console.WriteLine("Your answer is " + c.ToString());
        return 0;
    }
