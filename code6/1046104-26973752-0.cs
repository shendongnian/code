    try
    {
        action();
    }
    catch (Exception exc)
    {
        Debug.WriteLine(exc.StackTrace);                
    }
