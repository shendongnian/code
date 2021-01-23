    public sealed class AsyncSubject<T> : ISubject<T>, ISubject<T, T>, IObserver<T>, IObservable<T>, IDisposable, INotifyCompletion
    {
        // Fields
        private Exception _exception;
        private readonly object _gate;
        private bool _hasValue;
        private bool _isDisposed;
        private bool _isStopped;
        private ImmutableList<IObserver<T>> _observers;
        private T _value;
    
        // Methods
        public AsyncSubject();
        private void CheckDisposed();
        public void Dispose();
        public AsyncSubject<T> GetAwaiter();
        public T GetResult();
        public void OnCompleted();
        public void OnCompleted(Action continuation);
        private void OnCompleted(Action continuation, bool originalContext);
        public void OnError(Exception error);
        public void OnNext(T value);
        public IDisposable Subscribe(IObserver<T> observer);
    
        // Properties
        public bool HasObservers { get; }
        public bool IsCompleted { get; }
