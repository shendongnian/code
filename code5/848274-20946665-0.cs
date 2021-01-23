    public  class ReportingProgress<T> : Progress<T>, IProgress<T>
    {
        public ReportingProgress()
        {
        }
        public ReportingProgress(Action<T> handler)
            : base(handler)
        {
        }
        public void Report(T value)
        {
            this.OnReport(value);
        }
    }
