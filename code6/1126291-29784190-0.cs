    int MyMethod(object arg0, int arg1)
    {
        OnEntry();
        try
        {
            // YOUR CODE HERE 
            OnSuccess();
            return returnValue;
        }
        catch ( Exception e )
        {
            OnException();
        }
        finally
        {
            OnExit();
        }
    }
