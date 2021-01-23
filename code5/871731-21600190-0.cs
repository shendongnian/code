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
            throw new Exception("Your message", ex);
        }
    }
