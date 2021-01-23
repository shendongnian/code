    void Main()
    {
        Injectable i1 = new Injectable();
        Injectable i2 = new Injectable(new Injected("A"));
        Injectable i3 = new Injectable(new Injected("A"), new Injected("B"));
        
        Debug.WriteLine("dispose a and b");
        i1.Dispose();
        
        Debug.WriteLine("dispose b");
        i2.Dispose();
        
        Debug.WriteLine("no dispose");
        i3.Dispose();
    }
    
    public class Injected : IDisposable
    {
        public Injected(string name) { Name = name; }
        public string Name { get; set; }
        public void Dispose() { Debug.WriteLine(Name + " disposed"); }
    }
    
    public class Injectable : IDisposable
    {
        private Ownable<Injected> _A;
        private Ownable<Injected> _B;
        
        public Injectable(Injected a, Injected b)
        {
            _A = new Ownable<Injected>(a, false);
            _B = new Ownable<Injected>(b, false);
        }
        
        public Injectable(Injected a)
        {
            _A = new Ownable<Injected>(a, false);
            _B = new Ownable<Injected>(new Injected("B"), true);
        }
        
        public Injectable()
        {
            _A = new Ownable<Injected>(new Injected("A"), true);
            _B = new Ownable<Injected>(new Injected("B"), true);
        }
        
        public void Dispose()
        {
            _A.Dispose();
            _B.Dispose();
        }
    }
    
    public class Ownable<T> : IDisposable
        where T : class
    {
        private readonly T _Instance;
        private readonly Action _CleanupAction;
        
        public Ownable(T instance, bool isOwned)
        {
            _Instance = instance;
            
            if (isOwned)
            {
                IDisposable disposable = instance as IDisposable;
                if (disposable == null)
                    throw new NotSupportedException("Unable to clean up owned object, does not implement IDisposable");
                    
                _CleanupAction = () => disposable.Dispose();
            }
        }
        
        public Ownable(T instance, Action cleanupAction)
        {
            _Instance = instance;
            _CleanupAction = cleanupAction;
        }
        
        public T Instance { get { return _Instance; } }
        
        public void Dispose()
        {
            if (_CleanupAction != null)
                _CleanupAction();
        }
    }
