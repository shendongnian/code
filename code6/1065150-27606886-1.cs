    private void SaveChanges()
    {
        using(var scope = new TransactionScope())
        {
            var log = CreateRequest();
            bool saveLogSuccess = CreateLogEntry(log);
    
            if (saveLogSuccess)
            {
                scope.Complete();
            }
        }
    }    
    private LogEntry CreateRequest()
    {
        var req = new Request { Id = 1, Value = 2 };
        var log = new LogEntry { RequestId = 1, State = "OK" };
        using(var requestsCtx = new RequestsContext())
        {
            requestsCtx.Requests.Add(req);
    
            try
            {
                requestsCtx.SaveChanges();
            }
            catch(Exception ex)
            {
                log.State = "Error: " + ex.Message;
            }
            finally
            {
                return log;
            }
        }
    }
    private bool CreateLogEntry(LogEntry log)
    {
        using(var logsCtx = new LogsContext())
        {
            try
            {
                logsCtx.Logs.Add(log);
    
                logsCtx.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
