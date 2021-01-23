    [WebMethod]
    public void ExceptionTest()
    {
        try
        {
            throw new Exception("An Error Happened");
        }
        catch (Exception ex)
        {
            evlWebServiceLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
            PreserveStackTrace(ex);
            throw ex;
        }
    }
