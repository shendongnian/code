    // Safe (in terms of memory barriers)
    public class BusyIndicator
    {
        private int busy = 0;
        public bool IsBusy
        {
            get { return Interlocked.CompareExchange(ref busy, 0, 0) == 1; }
            set { Interlocked.Exchange(ref busy, value ? 1 : 0); }
        }
    }
