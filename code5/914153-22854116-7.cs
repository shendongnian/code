    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        // http://stackoverflow.com/q/22852251/1768303
        public class Program
        {
            class Resource : IDisposable
            {
                public void Dispose()
                {
                    Console.WriteLine("Resource.Dispose");
                }
    
                ~Resource()
                {
                    Console.WriteLine("~Resource");
                }
            }
    
            async Task SleepAsync(int milliseconds, Awaiter awaiter)
            {
                using (var resource = new Resource())
                {
                    Stopwatch timer = Stopwatch.StartNew();
                    do
                    {
                        await awaiter;
                    }
                    while (timer.ElapsedMilliseconds < milliseconds);
                }
                Console.WriteLine("Exit SleepAsync");
            }
    
            void AwaiterTest()
            {
                var awaiter = new Awaiter();
                var task = SleepAsync(100, awaiter);
                awaiter.MoveNext();
                Thread.Sleep(500);
    
                //while (awaiter.MoveNext()) ;
                awaiter.Dispose();
                task.Dispose();
            }
    
            public static void Main(string[] args)
            {
                new Program().AwaiterTest();
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                GC.WaitForPendingFinalizers();
                Console.ReadLine();
            }
    
            // custom awaiter
            public class Awaiter :
                System.Runtime.CompilerServices.INotifyCompletion,
                IDisposable
            {
                Action _continuation;
                readonly CancellationTokenSource _cts = new CancellationTokenSource();
    
                public Awaiter()
                {
                    Console.WriteLine("Awaiter()");
                }
    
                ~Awaiter()
                {
                    Console.WriteLine("~Awaiter()");
                }
    
                public void Cancel()
                {
                    _cts.Cancel();
                }
    
                // let the client observe cancellation
                public CancellationToken Token { get { return _cts.Token; } }
    
                // resume after await, called upon external event
                public bool MoveNext()
                {
                    if (_continuation == null)
                        return false;
    
                    var continuation = _continuation;
                    _continuation = null;
                    continuation();
                    return _continuation != null;
                }
    
                // custom Awaiter methods
                public Awaiter GetAwaiter()
                {
                    return this;
                }
    
                public bool IsCompleted
                {
                    get { return false; }
                }
    
                public void GetResult()
                {
                    this.Token.ThrowIfCancellationRequested();
                }
    
                // INotifyCompletion
                public void OnCompleted(Action continuation)
                {
                    _continuation = continuation;
                }
    
                // IDispose
                public void Dispose()
                {
                    Console.WriteLine("Awaiter.Dispose()");
                    if (_continuation != null)
                    {
                        Cancel();
                        MoveNext();
                    }
                }
            }
        }
    }
