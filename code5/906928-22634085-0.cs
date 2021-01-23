    try
    {
        preset = constructor.Invoke(new object[] { package }) as IExportPreset;
    }
    catch (Exception e)
    {
        Exception baseEx = e.GetBaseException();
        Utilities.Log("GetBaseException", baseEx.StackTrace);
    
        throw;
    }
