    public class ObservableToINPCObject<T> : ReactiveObject, IDisposable
    {
        ObservableAsPropertyHelper<T> _ValueHelper;
        public T Value {
            get { return _ValueHelper.Value; }
        }
    
        public ObservableToINPCObject(IObservable<T> source, T initial = default(T))
        {
            _ValueHelper = source.ToProperty(this, p=>p.Value, initial);
        }
        
        public Dispose(){
            _ValueHelper.Dispose();
        }
    }
    
