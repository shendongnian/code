    public static int Execute(string[] args)
    {
        // If we're a console host then print exceptions to stderr
        var printExceptionsToStdError = Environment.GetEnvironmentVariable(EnvironmentNames.ConsoleHost) == "1";
        try
        {
            return ExecuteAsync(args).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            if (printExceptionsToStdError)
            {
                PrintErrors(ex);
                return 1;
            }
            throw;
        }
    }
