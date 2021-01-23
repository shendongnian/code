    private Semaphore CompileSemaphore = new Semaphore(1, 1);
    private bool Compile()
    {
        if (!CompileSemaphore.WaitOne(0))
        {
            // Lock already taken. There is a compile in progress.
            return false;
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
            CompileSemaphore.Releae();
        }
    }
