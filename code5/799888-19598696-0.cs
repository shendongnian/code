    // System.Data.Common.DbCommand
    public virtual Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return ADP.CreatedTaskWithCancellation<int>();
        }
        CancellationTokenRegistration cancellationTokenRegistration = default(CancellationTokenRegistration);
        if (cancellationToken.CanBeCanceled)
        {
            cancellationTokenRegistration = cancellationToken.Register(new Action(this.CancelIgnoreFailure));
        }
        Task<int> result;
        try
        {
            result = Task.FromResult<int>(this.ExecuteNonQuery());
        }
        catch (Exception ex)
        {
            cancellationTokenRegistration.Dispose();
            result = ADP.CreatedTaskWithException<int>(ex);
        }
        return result;
    }
