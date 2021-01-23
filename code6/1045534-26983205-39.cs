    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            static async Task TestAsync()
            {
                var tcs = new TaskCompletionSource<bool>();
    
                WaitOrTimerCallbackProc callback = (a, b) =>
                    tcs.TrySetResult(true);
    
                //var gch = GCHandle.Alloc(tcs);
                try
                {
                    IntPtr timerHandle;
                    if (!CreateTimerQueueTimer(out timerHandle,
                            IntPtr.Zero,
                            callback,
                            IntPtr.Zero, 2000, 0, 0))
                        throw new System.ComponentModel.Win32Exception(
                            Marshal.GetLastWin32Error());
    
                    await tcs.Task;
                }
                finally
                {
                    //gch.Free();
    
                    GC.KeepAlive(callback);
                }
            }
    
            public static void Main(string[] args)
            {
                var task = TestAsync();
    
                Task.Run(() =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Starting GC");
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Console.WriteLine("GC Done");
                });
    
                task.Wait();
    
                Console.WriteLine("completed!");
                Console.Read();
            }
    
            // p/invoke
            delegate void WaitOrTimerCallbackProc(IntPtr lpParameter, bool TimerOrWaitFired);
    
            [DllImport("kernel32.dll")]
            static extern bool CreateTimerQueueTimer(out IntPtr phNewTimer,
               IntPtr TimerQueue, WaitOrTimerCallbackProc Callback, IntPtr Parameter,
               uint DueTime, uint Period, uint Flags);
        }
    }
