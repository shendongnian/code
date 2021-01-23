    private bool Compile()
    {
        if (!Monitor.TryEnter(compilerLock))
        {
            // Lock already taken. There is a compile in progress.
            return isCompiled;
        }
        try
        {
            if (!isCompiled && CanCompile())
            {
                CompileSynchronous();
            }
            return isCompiled;
        }
        finally
        {
            Monitor.Exit(compilerLock);
        }
    }
