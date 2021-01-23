    public interface IResetter
    {
        IObservable<T> MakeResettable<T>(Func<IObservable<T>> selector);
    }
    public class Resetter : IResetter
    {
        private Subject<Unit> _Resetter = new Subject<Unit>();
        public void Reset()
        {
            _Resetter.OnNext(Unit.Default);
        }
        public IObservable<T> MakeResettable<T>(Func<IObservable<T>> selector)
        {
            return
                _Resetter
                    .StartWith(Unit.Default)
                    .Select(_ => Observable.Defer(() => selector()))
                    .Switch()
                    .Publish().RefCount();
        }
    }
