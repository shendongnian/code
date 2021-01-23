    try
    {
        //code that fires the error
    }
    catch (ProviderIncompatibleException ex)
    {
        SqlException baseException = ex.GetBaseException() as SqlException;
        Console.WriteLine(baseException.Server);
    }
