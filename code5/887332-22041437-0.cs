    public static async Task RunJobAsync(job)
    {
        try
        {
             Task firstTask = someAsyncMethodThatReturnsVoidTask();
             Task secondTask = firstTask.ContinueWith(t => someCosoleLoggingCode());
             await secondTask;
        }
        catch (Exception ex)
        {
            someExceptionHandlingCode();
        }
    }
