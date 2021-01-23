    public static async Task RunJobAsync(job)
    {
      try
      {
        await someAsyncMethodThatReturnsVoidTask();
      }
      catch (Exception ex)
      {
        someExceptionHandlingCode();
      }
      finally
      {
        someCosoleLoggingCode();
      }
    }
