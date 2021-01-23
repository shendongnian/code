    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
        
    namespace ConsoleApplication
    {
        class Program
        {
            // Test task
            static async Task TestAsync(CancellationToken token)
            {
                using (var awaiter = new Awaiter())
                {
                    WaitOrTimerCallbackProc callback = (a, b) =>
                        awaiter.Continue();
        
                    IntPtr timerHandle;
                    if (!CreateTimerQueueTimer(out timerHandle,
                            IntPtr.Zero,
                            callback,
                            IntPtr.Zero, 500, 500, 0))
                        throw new System.ComponentModel.Win32Exception(
                            Marshal.GetLastWin32Error());
        
                    try
                    {
                        var i = 0;
                        while (true)
                        {
                            token.ThrowIfCancellationRequested();
                            await awaiter;
                            Console.WriteLine("tick: " + i++);
                        }
                    }
                    finally
                    {
                        DeleteTimerQueueTimer(IntPtr.Zero, timerHandle, IntPtr.Zero);
                    }
                }
            }
        
            // Entry point
            static void Main(string[] args)
            {
                // cancel in 3s
                var testTask = TestAsync(new CancellationTokenSource(3 * 1000).Token);
     
                Thread.Sleep(1000);
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
    
                Thread.Sleep(2000);
                Console.WriteLine("Press Enter to GC...");
                Console.ReadLine();
    
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        
            // Custom awaiter
            public class Awaiter : 
                System.Runtime.CompilerServices.INotifyCompletion,
                IDisposable
            {
                Action _continuation;
                GCHandle _hold = new GCHandle();
        
                public Awaiter()
                {
                    Console.WriteLine("Awaiter()");
                }
        
                ~Awaiter()
                {
                    Console.WriteLine("~Awaiter()");
                }
    
                public void ReleaseHold()
                {
                    if (_hold.IsAllocated)
                        _hold.Free();
                }
        
                // resume after await, called upon external event
                public void Continue()
                {
                    Action continuation;
        
                    // it's OK to use lock (this)
                    // the C# compiler would never do this,
                    // because it's slated to work with struct awaiters
                    lock (this)
                    {
                        continuation = _continuation;
                        _continuation = null;
                        ReleaseHold();
                    }
        
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
                    lock (this)
                    {
                        ReleaseHold();
                        _continuation = continuation;
                        _hold = GCHandle.Alloc(_continuation);
                    }
                }
        
                // IDispose
                public void Dispose()
                {
                    lock (this)
                    {
                        _continuation = null;
                        ReleaseHold();
                    }
                }
            }
        
            // p/invoke
            delegate void WaitOrTimerCallbackProc(IntPtr lpParameter, bool TimerOrWaitFired);
        
            [DllImport("kernel32.dll")]
            static extern bool CreateTimerQueueTimer(out IntPtr phNewTimer,
                IntPtr TimerQueue, WaitOrTimerCallbackProc Callback, IntPtr Parameter,
                uint DueTime, uint Period, uint Flags);
        
            [DllImport("kernel32.dll")]
            static extern bool DeleteTimerQueueTimer(IntPtr TimerQueue, IntPtr Timer,
                IntPtr CompletionEvent);
        }
    }
