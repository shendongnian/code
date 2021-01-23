    static void ExecCommand<TResult>(Command<TResult> command) 
        where TResult : CommandResult, new()
    {
        TResult res = command.ParseReply(null);
        // use base class from now on
        var cmdRes = (CommandResult)res;
        // add to queue, etc.
    }
