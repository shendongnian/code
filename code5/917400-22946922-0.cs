    public interface IProgress<T>
    {
        void Report(T data);
    }
    public class Progress<T> : IProgress<T>
    {
        SynchronizationContext context;
        public Progress()
        {
            context = SynchronizationContext.Current
                ?? new SynchronizationContext();
        }
        public Progress(Action<T> action)
            : this()
        {
            ProgressReported += action;
        }
        public event Action<T> ProgressReported;
        void IProgress<T>.Report(T data)
        {
            var action = ProgressReported;
            if (action != null)
            {
                context.Post(arg => action((T)arg), data);
            }
        }
    }
