    using(var requestsCtx = new RequestsContext())
    using(var logsCtx = new LogsContext())
    {
        var req = new Request { Id = 1, Value = 2 };
        requestsCtx.Requests.Add(req);
    
        var log = new LogEntry { RequestId = 1, State = "OK" };
        logsCtx.Logs.Add(log);
    
        using(var outerScope = new TransactionScope())
        {
            using(var innerScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    requestsCtx.SaveChanges();
                    innerScope.Complete();
                }
                catch(Exception ex)
                {
                    log.State = "Error: " + ex.Message;
                }
            }
    
            logsCtx.SaveChanges();
            outerScope.Complete();
        }
    }
