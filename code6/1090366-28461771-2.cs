    private void DoStuff()
    {
        try
        {
            this.DoSomethingThatCouldPotentiallyCauseTransientErrors(5);
        }
        catch (Exception ex)
        {
            // This would not be caught until the "retries" have occurred.
            this.HandleException(ex);
            return RedirectToAction("Index", "Error");
        }
    }
    
    private void DoSomethingThatCouldPotentiallyCauseTransientErrors(int retryAttemptsBeforeExceptionThrown)
    {
        // Note that this will *always throw an exception*, 
        // I'm (attempting to) simply demonstrate my point of how the transient errors could be defined.
    
        try
        {
            for (int i = 0; i < retryAttemptsBeforeExceptionThrown)
            {
                int x = 0;
                int y = 0;
    
                int result = x / y;
            }
        }
        catch (Exception)
        {
            if (i < retryAttemptsBeforeExceptionThrown-1)
            {
                // Swallow/ignore the exception, and retry
                // Note that anything hitting this block would be considered a "transient error", 
                // as we are not raising an exception
            }
            else
            {
                // Too many failed attempts have occurred, ***now*** we raise an exception to the caller
                throw;
            }
        }
    }
    
    private void HandleException(Exception ex)
    {
        // Implementation
    }
