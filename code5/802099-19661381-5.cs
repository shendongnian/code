    public class ProgressThrottler<T>: IProgress<T> {
        public ProgressThrottler(IProgress<T> progress) {
            _progress = progress ?? throw new ArgumentNullException("progress");
        }
    
        private readonly IProgress<T> _progress;
    
        public void Report(T value) {
            // Throttles the amount of calls
            bool reportProgressAfterThrottling = ...;
    
            if (reportProgressAfterThrottling) {
                _progress.Report(value);
            }
        }
    }
