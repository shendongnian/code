    public sealed class Status: IEquatable<Status>
    {
        public Status(bool isEnabled)
        {
            _isEnabled = isEnabled;
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
        }
        public bool IsDisabled
        {
            get { return !_isEnabled; }
        }
        public bool Equals(Status other)
        {
            return other != null && this.IsEnabled == other.IsEnabled;
        }
        public static implicit operator bool(Status status)
        {
            return status.IsEnabled;
        }
        public static Status Enabled
        {
            get { return _enabled; }
        }
        public static Status Disabled
        {
            get { return _disabled; }
        }
        private readonly bool _isEnabled;
        private static readonly Status _enabled  = new Status(true);
        private static readonly Status _disabled = new Status(false);
    }
