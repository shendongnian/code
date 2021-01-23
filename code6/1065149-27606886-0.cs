    var req = new Request { Id = 1, Value = 2 };
    var log = new LogEntry { RequestId = 1, State = "OK" };
    
    using(var scope = new TransactionScope())
    {
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
        }
    
        scope.Complete();
    }
    
    using(var newScope = new TransactionScope())
    {
        using(var logsCtx = new LogsContext())
        {
            logsCtx.Logs.Add(log);
    
            logsCtx.SaveChanges();
        }
        newScope.Complete();
    }
