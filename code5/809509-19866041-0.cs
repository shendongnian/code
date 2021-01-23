    var transactionFailed = false;
    try
    {
        using (var tx = new TransactionScope())
        {
            tx.Complete();
        }
    }
    catch (TransactionAbortedException ex)
    {
        transactionFailed = true;
        writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
    }
    catch (ApplicationException ex)
    {
        transactionFailed = true;
        writer.WriteLine("ApplicationException Message: {0}", ex.Message);
    }
    catch (Exception ex)
    {
        transactionFailed = true;
        writer.WriteLine("Exception Message: {0}", ex.Message);
    }
