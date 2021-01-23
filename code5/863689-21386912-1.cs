    public class ReactiveProperty<T> : IObservable<T>, IDisposable, INotifyPropertyChanged, IReactiveProperty, INotifyDataErrorInfo
    {
        public T Value
        {
            get { return latestValue; }
            set { anotherTrigger.OnNext(value); }
        }
        // ...
    }
