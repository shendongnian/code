    public static bool Test()
    {
        bool returnValueOfInvoke = false;
        try
        {
            typeof(Program).GetMethod("OtherMethod").Invoke(null, null);    
        }
        catch(TargetInvocationException ex)
        {
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
        }
        return returnValueOfInvoke;
    }
    
    public static void OtherMethod()
    {
        throw new InvalidOperationException();
    }
