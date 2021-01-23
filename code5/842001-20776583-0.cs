    private ManualResetEvent jobSignal = new ManualResetEvent(false);
    public AutoRenewLease(CloudBlockBlob blob)
    {
        _blob = blob;
        // acquire lease
        LeaseId = blob.TryAcquireLease(TimeSpan.FromSeconds(60));
        if (!HasLease) return;
        // keep renewing lease
        _renewalThread = new Thread(() =>
        {
            try
            {
                while (_isRenewing)
                {
                    if(jobSignal.WaitOne(TimeSpan.FromSeconds(40.0)))
                    {
                        //Disposed so stop working
                        jobSignal.Dispose();
                        jobSignal = null;
                        return;
                    }
                    if (_isRenewing)
                        blob.RenewLease(AccessCondition
                            .GenerateLeaseCondition(LeaseId));
                }
            }
            catch (Exception ex) {//atleast log it }
        });
        _renewalThread.Start();
    }
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing && _renewalThread != null)
        {
            jobSignal.Set();//Signal the thread to stop working
            _isRenewing = false;
            _blob.ReleaseLease(AccessCondition
                .GenerateLeaseCondition(LeaseId));
            _renewalThread = null;
        }
        _disposed = true;
    }
