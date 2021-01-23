    void Main()
    {
        var tests = new Tests();
        tests.Test();
    }
    
    public class Foo
    {
        private BehaviorSubject<bool> _isActive;
        private BehaviorSubject<bool> _isBroken;
        private BehaviorSubject<bool> _status;
        
        public bool IsActive
        {
            get { return _isActive.Value; }
            set { _isActive.OnNext(value); }
        }
        
        public bool IsBroken { get { return _isBroken.Value; } }
        public bool Status { get { return _status.Value; } }
        
        public Foo(IObservable<MyObject> valueStream, IScheduler scheduler)
        {
            _isActive = new BehaviorSubject<bool>(false);
            _isBroken = new BehaviorSubject<bool>(false);
            _status = new BehaviorSubject<bool>(false);
            
            // for debugging purposes
            _isActive.Subscribe(a => Console.WriteLine(
                 "Time: " + scheduler.Now.TimeOfDay + " IsActive: " + a));
            _isBroken.Subscribe(a => Console.WriteLine(
                 "Time: " + scheduler.Now.TimeOfDay + " IsBroken: " + a));
            _status.Subscribe(a => Console.WriteLine(
                  "Time: " + scheduler.Now.TimeOfDay + " Status: " + a));
            
            valueStream.Subscribe(UpdateValues);
            
            Observable.CombineLatest(
                        _isActive,
                        _status,
                        (a,s) => a & !s).DistinctUntilChanged()
                    .Where(p => p)
                    .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(3),
                                                      scheduler)
                                               .TakeUntil(_status.Where(st => st)))
                    .Subscribe(_ => _isBroken.OnNext(true));            
        }
        
        private void UpdateValues(MyObject obj)
        {
            _status.OnNext(obj.SpecialValue);
        }   
    }   
    
    public class MyObject
    {
        public MyObject(bool specialValue)
        {
            SpecialValue = specialValue;
        }
        
        public bool SpecialValue { get; set; }
    }
    
    public class Tests : ReactiveTest
    {
        public void Test()
        {
            var testScheduler = new TestScheduler();
            
            var statusStream = testScheduler.CreateColdObservable<bool>(
                OnNext(TimeSpan.FromSeconds(1).Ticks, false),
                OnNext(TimeSpan.FromSeconds(3).Ticks, true),
                OnNext(TimeSpan.FromSeconds(5).Ticks, false));
                
            var activeStream = testScheduler.CreateColdObservable<bool>(
                OnNext(TimeSpan.FromSeconds(1).Ticks, false),
                OnNext(TimeSpan.FromSeconds(6).Ticks, true));           
                
            var foo = new Foo(statusStream.Select(b => new MyObject(b)), testScheduler);
            
            activeStream.Subscribe(b => foo.IsActive = b);       
            
            testScheduler.Start();               
        }        
    }
