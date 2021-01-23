    public static class ValveSubjectExtensions
    {
        public static IValveSubject<T> Synchronize<T>(this IValveSubject<T> valve)
        {
            return Synchronize(valve, new object());
        }
        public static IValveSubject<T> Synchronize<T>(this IValveSubject<T> valve, object gate)
        {
            return new SynchronizedValveAdapter<T>(valve, gate);
        }
        public static IFlushableValveSubject<T> Synchronize<T>(this IFlushableValveSubject<T> valve)
        {
            return Synchronize(valve, new object());
        }
        public static IFlushableValveSubject<T> Synchronize<T>(this IFlushableValveSubject<T> valve, object gate)
        {
            return new SynchronizedFlushableValveAdapter<T>(valve, gate);
        }
    }
   
    internal class SynchronizedValveAdapter<T> : IValveSubject<T>
    {
        private readonly object gate;
        private readonly IValveSubject<T> valve;
        public SynchronizedValveAdapter(IValveSubject<T> valve, object gate)
        {
            this.valve = valve;
            this.gate = gate;
        }
        public void OnNext(T value)
        {
            lock (gate)
            {
                valve.OnNext(value);    
            }
        }
        public void OnError(Exception error)
        {
            lock (gate)
            {
                valve.OnError(error);
            }
        }
        public void OnCompleted()
        {
            lock (gate)
            {
                valve.OnCompleted();
            }
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return valve.Subscribe(observer);
        }
        public void Open()
        {
            lock (gate)
            {
                valve.Open();
            }
        }
        public void Close()
        {
            lock (gate)
            {
                valve.Close();
            }
        }
     }
     
     internal class SynchronizedFlushableValveAdapter<T> : SynchronizedValveAdapter<T>, IFlushableValveSubject<T>
     {
        private readonly object gate;
        private readonly IFlushableValveSubject<T> valve;
        public SynchronizedFlushableValveAdapter(IFlushableValveSubject<T> valve, object gate)
            : base(valve, gate)
        {
            this.valve = valve;
            this.gate = gate;
        }
        public IObservable<T> FlushAndClose()
        {
            lock (gate)
            {
                return valve.FlushAndClose();
            }
        }
    } 
