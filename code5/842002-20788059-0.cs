    public class AutoRenewLease : IDisposable
    {
        private readonly CloudBlockBlob _blob;
        public readonly string LeaseId;
        private System.Threading.Timer _renewalTimer;
        private volatile bool _isRenewing = true;
        private bool _disposed;
        public bool HasLease { get { return LeaseId != null; } }
        public AutoRenewLease(CloudBlockBlob blob)
        {
            _blob = blob;
            // acquire lease
            LeaseId = blob.TryAcquireLease(TimeSpan.FromSeconds(60));
            if (!HasLease) return;
            _renewalTimer = new System.Threading.Timer(
            {
                if (_isRenewing)
                {
                    blob.RenewLease(AccessCondition
                        .GenerateLeaseCondition(LeaseId));
                }
            }, null, TimeSpan.FromSeconds(40), TimeSpan.FromSeconds(40));
        ~AutoRenewLease()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing && _renewalTimer != null)
            {
                _isRenewing = false;
                _renewalTimer.Dispose();
                _blob.ReleaseLease(AccessCondition
                    .GenerateLeaseCondition(LeaseId));
                _renewalThread = null;
            }
            _disposed = true;
        }
    }
