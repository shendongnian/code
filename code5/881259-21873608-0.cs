    public void GetSomeData(Action<DataTable> processDataTableAction)
    {
        try
        { 
            ... ( get the data )
            processDataTableAction(dt);
        }
        catch
        {
            // handle exceptions
        }
        finally
        {
            dt.Dispose();
        }
    }
