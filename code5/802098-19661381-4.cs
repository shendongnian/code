    public class ProgressThrottler<in T>: IProgress<T> {
        public ProgressThrottler(IProgress<T> progress) {
            if (progress == null)
                throw new ArgumentNullException("progress");
    
            _progress = progress;
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
