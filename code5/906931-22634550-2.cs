    try
    {
        preset = constructor.Invoke(new object[] { package }) as IExportPreset;
    }
    catch (Exception e)
    {
        Exception baseEx = e.GetBaseException();
        
        Utilities.Log("GetBaseException", baseEx.StackTrace);
        baseEx.PreserveStackTrace();
        if (baseEx != null)
            throw baseEx;
        else
            throw e;
    }
    
