    public BaseClass()
    {
        StackTrace stackTrace = new StackTrace();
        MethodBase callingMethod = stackTrace.GetFrame(1).GetMethod();
        Type callingType = callingMethod.DeclaringType;
        // Then as above, check the type as required
    }
