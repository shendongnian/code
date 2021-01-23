    /// <summary>
    /// Subject offering Open() and Close() methods, with built-in buffering.
    /// Note that closing the valve in the observer is supported.
    /// </summary>
    /// <remarks>As is the case with other Rx subjects, this class is not thread-safe, in that
    /// order of elements in the output is indeterministic in the case of concurrent operation 
    /// of Open()/Close()/OnNext()/OnError(). To guarantee strict order of delivery even in the 
    /// case of concurrent access, <see cref="ValveSubjectExtensions.Synchronize{T}(NEXThink.Finder.Utils.Rx.IValveSubject{T})"/> can be used.</remarks>
    /// <typeparam name="T">Elements type</typeparam>
    public class ValveSubject<T> : IValveSubject<T>
    {
        private enum Valve
        {
            Open,
            Closed
        }
        private readonly Subject<T> input = new Subject<T>();
        private readonly BehaviorSubject<Valve> valveSubject = new BehaviorSubject<Valve>(Valve.Open);
        private readonly Subject<T> output = new Subject<T>();
        public ValveSubject()
        {
            var valveOperations = valveSubject.DistinctUntilChanged();
            input.Buffer(
                bufferOpenings: valveOperations.Where(v => v == Valve.Closed),
                bufferClosingSelector: _ => valveOperations.Where(v => v == Valve.Open))
                .SelectMany(t => t).Subscribe(input);
            input.Where(t => valveSubject.Value == Valve.Open).Subscribe(output);
        }
        public bool IsOpen
        {
            get { return valveSubject.Value == Valve.Open; }
        }
        public bool IsClosed
        {
            get { return valveSubject.Value == Valve.Closed; }
        }
        public void OnNext(T value)
        {
            input.OnNext(value);
        }
        public void OnError(Exception error)
        {
            input.OnError(error);
        }
        public void OnCompleted()
        {
            output.OnCompleted();
            input.OnCompleted();
            valveSubject.OnCompleted();
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return output.Subscribe(observer);
        }
        public void Open()
        {
            valveSubject.OnNext(Valve.Open);
        }
        public void Close()
        {
            valveSubject.OnNext(Valve.Closed);
        }
    }
    public interface IValveSubject<T>:ISubject<T>
    {
        void Open();
        void Close();
    }
