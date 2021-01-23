    try
    {
        // do something
    }
    catch (StorageException ex)
    {
        ApplicationException aex = new ApplicationException("StorageException in SaveTransactionsToAzure()", ex);
        aex.Source = "SaveTransactionsToAzure()";
        aex.Data.Add("HttpStatusCode", ex.RequestInformation.HttpStatusCode);
        aex.Data.Add("ErrorCode", ex.RequestInformation.ExtendedErrorInformation.ErrorCode);
        aex.Data.Add("ErrorMessage", ex.RequestInformation.ExtendedErrorInformation.ErrorMessage);
        throw aex;
    }
