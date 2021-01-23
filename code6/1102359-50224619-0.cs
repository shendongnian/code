    public interface IDataUpdater
    {
        [Hangfire.AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        void UpdateData();
    }
