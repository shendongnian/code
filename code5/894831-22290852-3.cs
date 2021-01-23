    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            // Original version with async/await
            /*
            static async Task TestAsync()
            {
                Console.WriteLine("Enter TestAsync");
                var awaiter = new Awaiter();
                //var hold = GCHandle.Alloc(awaiter);
    
                var i = 0;
                while (true)
                {
                    //await awaiter;
                    await Task.Delay(5000);
                    Console.WriteLine("tick: " + i++);
                }
                Console.WriteLine("Exit TestAsync");
            }
            */
            // Manually coded state machine version
    
            struct StateMachine: IAsyncStateMachine
            {
                public int _state;
                public Awaiter _awaiter;
                public AsyncTaskMethodBuilder _builder;
    
                public void MoveNext()
                {
                    Console.WriteLine("StateMachine.MoveNext, state: " + this._state);
                    switch (this._state)
                    {
                        case -1:
                            {
                                this._awaiter = new Awaiter();
                                goto case 0;
                            };
                        case 0:
                            {
                                this._state = 0;
                                var awaiter = this._awaiter;
                                this._builder.AwaitOnCompleted(ref awaiter, ref this);
                                return;
                            };
    
                        default:
                            throw new InvalidOperationException();
                    }
                }
    
                public void SetStateMachine(IAsyncStateMachine stateMachine)
                {
                    Console.WriteLine("StateMachine.SetStateMachine, state: " + this._state);
                    this._builder.SetStateMachine(stateMachine);
                    // s_strongRef = stateMachine;
                }
    
                static object s_strongRef = null;
            }
    
            static Task TestAsync()
            {
                StateMachine stateMachine = new StateMachine();
                stateMachine._state = -1;
    
                stateMachine._builder = AsyncTaskMethodBuilder.Create();
                stateMachine._builder.Start(ref stateMachine);
    
                return stateMachine._builder.Task;
            }
    
            public static void Main(string[] args)
            {
                var task = TestAsync();
                Thread.Sleep(1000);
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
    
            // custom awaiter
            public class Awaiter :
                System.Runtime.CompilerServices.INotifyCompletion
            {
                Action _continuation;
    
                public Awaiter()
                {
                    Console.WriteLine("Awaiter()");
                }
    
                ~Awaiter()
                {
                    Console.WriteLine("~Awaiter()");
                }
    
                // resume after await, called upon external event
                public void Continue()
                {
                    var continuation = Interlocked.Exchange(ref _continuation, null);
                    if (continuation != null)
                        continuation();
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
                }
    
                // INotifyCompletion
                public void OnCompleted(Action continuation)
                {
                    Console.WriteLine("Awaiter.OnCompleted");
                    Volatile.Write(ref _continuation, continuation);
                }
            }
        }
    }
