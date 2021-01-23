    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            new Program().RunAsync().Wait();
        }
    
        async Task RunAsync()
        {
            var ready1 = new CoroutineEvent(initialState: true);
            var go1 = new CoroutineEvent(initialState: false);
    
            var ready2 = new CoroutineEvent(initialState: true);
            var go2 = new CoroutineEvent(initialState: false);
    
            var ready3 = new CoroutineEvent(initialState: true);
            var go3 = new CoroutineEvent(initialState: false);
    
            var waiter1 = Waiter(1, go1, ready1);
            var waiter2 = Waiter(2, go2, ready2);
            var waiter3 = Waiter(3, go3, ready3);
    
            while (true)
            {
                await ready1.WaitAsync();
                ready1.Reset();
    
                await ready2.WaitAsync();
                ready2.Reset();
    
                await ready3.WaitAsync();
                ready2.Reset();
    
                Console.WriteLine("new round");
    
                go1.Set();
                go2.Set();
                go3.Set();
            }
        }
    
        async Task Waiter(int n, CoroutineEvent go, CoroutineEvent ready)
        {
            while (true)
            {
                await go.WaitAsync();
                go.Reset();
    
                await Task.Delay(500).ConfigureAwait(false);
                Console.WriteLine("Waiter #" + n + " + run, thread: " + 
                    Thread.CurrentThread.ManagedThreadId);
    
                ready.Set();
            }
        }
    
        public class CoroutineEvent
        {
            volatile bool _signalled;
            readonly Awaiter _awaiter;
    
            public CoroutineEvent(bool initialState = true)
            {
                _signalled = initialState;
                _awaiter = new Awaiter(this);
            }
    
            public bool IsSignalled { get { return _signalled; } }
    
            public void Reset()
            {
                _signalled = false;
            }
    
            public void Set()
            {
                var wasSignalled = _signalled;
                _signalled = true;
                if (!wasSignalled)
                    _awaiter.Continue();
            }
    
            public Awaiter WaitAsync()
            {
                return _awaiter;
            }
    
            public class Awaiter: System.Runtime.CompilerServices.INotifyCompletion
            {
                volatile Action _continuation;
                readonly CoroutineEvent _owner;
    
                internal Awaiter(CoroutineEvent owner)
                {
                    _owner = owner;
                }
    
                static void ScheduleContinuation(Action continuation)
                {
                    ThreadPool.QueueUserWorkItem((state) => ((Action)state)(), continuation);
                }
    
                public void Continue()
                {
                    lock (this)
                    {
                        var continuation = _continuation;
                        _continuation = null;
                        if (continuation != null)
                            ScheduleContinuation(continuation);
                    }
                }
    
                // custom Awaiter methods
    
                public Awaiter GetAwaiter()
                {
                    return this;
                }
    
                public bool IsCompleted
                {
                    get
                    {
                        lock (this)
                            return _owner.IsSignalled;
                    }
                }
    
                public void GetResult()
                {
                }
    
                // INotifyCompletion
    
                public void OnCompleted(Action continuation)
                {
                    lock (this)
                    {
                        if (_continuation != null)
                            throw new InvalidOperationException();
    
                        if (_owner.IsSignalled)
                            ScheduleContinuation(continuation);
                        else
                            _continuation = continuation;
                    }
                }
            }
        }
    }
