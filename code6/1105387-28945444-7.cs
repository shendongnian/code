    public class RollingReplaySubject<T> : ISubject<T>
    {
        private readonly ReplaySubject<IObservable<T>> _subjects;
        private readonly IObservable<T> _concatenatedSubjects;
        private ISubject<T> _currentSubject;
        public RollingReplaySubject()
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
            // a quick way to make the current ReplaySubject unreachable
            // except to in-flight observers, and not hold up collection
            _currentSubject = new Subject<T>();       
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _concatenatedSubjects.Subscribe(observer);
        }
    }
