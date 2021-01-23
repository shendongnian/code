    public void DeleteLog(int Id)
    {
        using (var tran = new TransactionScope())
        {
            getDataContext.recordLogs(Id);
            getDataContext.deleteLogs(Id);
            tran.Complete();
        }
    }
