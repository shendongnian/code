    [HandleProcessCorruptedStateExceptions]
    [SecurityCritical]
    public static void ThirdPartyCall()
    {
        try
        {
            ThirdPartyLibrary.DoWork();
        }
        catch (Exception ex)
        {   
            //This is pretty much the only thing we'd like to do...
            log.Fatal("Exception was thrown",ex);
            Environment.FailFast("Fatal exception in 3rd party library");
        }
    }
