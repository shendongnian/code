    TResult result;
    DataWriterStoreOperation task = dw.StoreAsync();
    
    try
    {
        result = task.GetResults();
    }
    finally
    {
        task.Close();
    }
