    catch (InvalidPluginExecutionException ex)
    {
        context.LogException(ex);
        // This error is already being thrown from the plugin, just throw
        if (context.PluginExecutionContext.IsolationMode == (int) IsolationMode.Sandbox)
        {
            if (Sandbox.ExceptionHandler.CanThrow(ex))
            {
                throw;
            }
        }
        else
        {
            throw;
        }
    }
    catch (Exception ex)
    {
        // Unexpected Exception occurred, log exception then wrap and throw new exception
        context.LogException(ex);
        ex = new InvalidPluginExecutionException(ex.Message, ex);
        if (context.PluginExecutionContext.IsolationMode == (int)IsolationMode.Sandbox)
        {
            if (Sandbox.ExceptionHandler.CanThrow(ex))
            {
                // ReSharper disable once PossibleIntendedRethrow - Wrap the exception in an InvalidPluginExecutionException
                throw ex;
            }
        }
        else
        {
            // ReSharper disable once PossibleIntendedRethrow - Wrap the exception in an InvalidPluginExecutionException
            throw ex;
        }
    }
