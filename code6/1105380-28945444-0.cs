    public class RolloverReplaySubject<T> : ISubject<T>
    {
        private readonly ReplaySubject<IObservable<T>> _subjects;
        private readonly IObservable<T> _concatenatedSubjects;
        private ReplaySubject<T> _currentSubject;
        public RolloverReplaySubject()
        {
            _subjects = new ReplaySubject<IObservable<T>>(1);
            _concatenatedSubjects = _subjects.Concat();
            _currentSubject = new ReplaySubject<T>();
            _subjects.OnNext(_currentSubject);
        }
        public void Clear()
        {
            _currentSubject.OnCompleted();
            _currentSubject = new ReplaySubject<T>();
            _subjects.OnNext(_currentSubject);
        }
        public void OnNext(T value)
        {
            _currentSubject.OnNext(value);
        }
        public void OnError(Exception error)
        {
            _currentSubject.OnError(error);
        }
        public void OnCompleted()
        {
            _currentSubject.OnCompleted();
            _subjects.OnCompleted();            
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _concatenatedSubjects.Subscribe(observer);
        }
    }
