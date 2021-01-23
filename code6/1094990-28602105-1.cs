    /// <summary>
    /// Subject with same semantics as <see cref="ValveSubject{T}"/>, but adding flushing out capability 
    /// which allows clearing the valve of any remaining elements before closing.
    /// </summary>
    /// <typeparam name="T">Elements type</typeparam>
    public class FlushableValveSubject<T> : IFlushableValveSubject<T>
    {
        private readonly BehaviorSubject<ValveSubject<T>> valvesSubject = new BehaviorSubject<ValveSubject<T>>(new ValveSubject<T>());
        private ValveSubject<T> CurrentValve
        {
            get { return valvesSubject.Value; }
        }
        public bool IsOpen
        {
            get { return CurrentValve.IsOpen; }
        }
        public bool IsClosed
        {
            get { return CurrentValve.IsClosed; }
        }
        public void OnNext(T value)
        {
            CurrentValve.OnNext(value);
        }
        public void OnError(Exception error)
        {
            CurrentValve.OnError(error);
        }
        public void OnCompleted()
        {
            CurrentValve.OnCompleted();
            valvesSubject.OnCompleted();
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return valvesSubject.Switch().Subscribe(observer);
        }
        public void Open()
        {
            CurrentValve.Open();
        }
        public void Close()
        {
            CurrentValve.Close();
        }
        /// <summary>
        /// Discards remaining elements in the valve and reset the valve into a closed state
        /// </summary>
        /// <returns>Replayable observable with any remaining elements</returns>
        public IObservable<T> FlushAndClose()
        {
            var previousValve = CurrentValve;
            valvesSubject.OnNext(CreateClosedValve());
            var remainingElements = new ReplaySubject<T>();
            previousValve.Subscribe(remainingElements);
            previousValve.Open();
            return remainingElements;
        }
        private static ValveSubject<T> CreateClosedValve()
        {
            var valve = new ValveSubject<T>();
            valve.Close();
            return valve;
        }
    }
    public interface IFlushableValveSubject<T> : IValveSubject<T>
    {
        IObservable<T> FlushAndClose();
    }
