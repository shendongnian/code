    using System;
    using System.Diagnostics;
    using System.Runtime.Remoting.Messaging;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    
    namespace TestApp.Controllers
    {
        /// <summary>
        /// TestController
        /// </summary>
        public class TestController : ApiController
        {
            public async Task<string> GetData()
            {
                Debug.WriteLine(String.Empty);
    
                Debug.WriteLine(new
                {
                    where = "before await",
                    thread = Thread.CurrentThread.ManagedThreadId,
                    context = SynchronizationContext.Current
                });
    
                // add some state to flow
                HttpContext.Current.Items.Add("_context_key", "_contextValue");
                CallContext.LogicalSetData("_key", "_value");
    
                var task = Task.Delay(100).ContinueWith(t =>
                {
                    Debug.WriteLine(new
                    {
                        where = "inside ContinueWith",
                        thread = Thread.CurrentThread.ManagedThreadId,
                        context = SynchronizationContext.Current
                    });
                    // return something as we only have the generic awaiter so far
                    return Type.Missing; 
                }, TaskContinuationOptions.ExecuteSynchronously);
    
                await task.ConfigureContinue(synchronously: true);
    
                Debug.WriteLine(new
                {
                    logicalData = CallContext.LogicalGetData("_key"),
                    contextData = HttpContext.Current.Items["_context_key"],
                    where = "after await",
                    thread = Thread.CurrentThread.ManagedThreadId,
                    context = SynchronizationContext.Current
                });
    
                return "OK";
            }
        }
    
        /// <summary>
        /// TaskExt
        /// </summary>
        public static class TaskExt
        {
            /// <summary>
            /// ConfigureContinue - http://stackoverflow.com/q/23062154/1768303
            /// </summary>
            public static ContextAwaiter<TResult> ConfigureContinue<TResult>(this Task<TResult> @this, bool synchronously = true)
            {
                return new ContextAwaiter<TResult>(@this, synchronously);
            }
    
            /// <summary>
            /// ContextAwaiter
            /// TODO: non-generic version 
            /// </summary>
            public class ContextAwaiter<TResult> :
                System.Runtime.CompilerServices.ICriticalNotifyCompletion
            {
                readonly bool _synchronously;
                readonly Task<TResult> _task;
    
                public ContextAwaiter(Task<TResult> task, bool synchronously)
                {
                    _task = task;
                    _synchronously = synchronously;
                }
    
                // awaiter methods
                public ContextAwaiter<TResult> GetAwaiter()
                {
                    return this;
                }
    
                public bool IsCompleted
                {
                    get { return _task.IsCompleted; }
                }
    
                public TResult GetResult()
                {
                    return _task.Result;
                }
    
                // ICriticalNotifyCompletion
                public void OnCompleted(Action continuation)
                {
                    UnsafeOnCompleted(continuation);
                }
    
                // Why UnsafeOnCompleted? http://blogs.msdn.com/b/pfxteam/archive/2012/02/29/10274035.aspx
                public void UnsafeOnCompleted(Action continuation)
                {
                    var syncContext = SynchronizationContext.Current;
                    var sameStackFrame = true; 
                    try
                    {
                        _task.ContinueWith(_ => 
                        {
                            if (null != syncContext)
                            {
                                // async if the same stack frame
                                if (sameStackFrame)
                                    syncContext.Post(__ => continuation(), null);
                                else
                                    syncContext.Send(__ => continuation(), null);
                            }
                            else
                            {
                                continuation();
                            }
                        }, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
                    }
                    finally
                    {
                        sameStackFrame = false;
                    }
                }
            }
        }
    }
