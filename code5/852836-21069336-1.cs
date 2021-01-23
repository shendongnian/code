    private void TestMethod()
    {
        // Do something
        if (conditionIsMet)
            return; // Exits the method immediately
        
        try
        {
            // Do something
            if (conditionIsMet)
                return;  // Statements in finally block will be executed before exiting the method
        }
        finally
        {
            // Do some cleanup
        }
        
        using (var disposableObj = new DisposableObject())
        {
            // Do something
            if (conditionIsMet)
                return;  // disposableObj will be disposed before exiting the method
        }
    }
