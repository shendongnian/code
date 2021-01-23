    // code adapted from 
    // http://social.msdn.microsoft.com/Forums/en-US/d51efcf0-7653-403e-95b6-bf5fb97bf16c/suspend-thread-of-a-process
    
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Threading;
    using System.ComponentModel;
    
    namespace SkypeLauncher
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process[] procs = Process.GetProcessesByName("skype");
                if (procs.Length == 0)
                {
                    Console.WriteLine("Skype not loaded. Launching. ");
                    Process.Start(Environment.ExpandEnvironmentVariables(@"%PROGRAMFILES(X86)%\Skype\Phone\Skype.exe"));
                    Thread.Sleep(8000); // wait to allow skype to start up & get into steady state
                }
    
                // wait to allow skype to start up & get into steady state, where "steady state" means
                // a lot of threads created
                Process proc = null;
                for (int i = 0; i < 50; i++)
                {
                    procs = Process.GetProcessesByName("skype");
                    if (procs != null)
                    {
                        proc = procs[0];
                        if (proc.Threads.Count > 10)
                            break;
                    }
                    Thread.Sleep(1000); // wait to allow skype to start up & get into steady state
                }
    
                // try multiple times; if not hanging after a while, give up. It must not be hanging!
                for (int i = 0; i < 50; i++)    
                {
                    // must reload process to get updated thread time info
                    procs = Process.GetProcessesByName("skype");
                    if (procs.Length == 0)
                    {
                        Console.WriteLine("Skype not loaded. Exiting. ");
                        return;
                    }
                    proc = procs[0];
    
                    // avoid case where exception thrown if thread is no longer around when looking at its CPU time, or
                    // any other reason why we can't read the time
                    var safeTotalProcessorTime = new Func<ProcessThread, double> (t => 
                        {
                            try { return t.TotalProcessorTime.TotalMilliseconds; }
                            catch (InvalidOperationException) { return 0; }
                        }
                    );
                
                    var threads = (from t in proc.Threads.OfType<ProcessThread>()
                                      orderby safeTotalProcessorTime(t) descending
                                      select new  
                                      {
                                          t.Id, 
                                          t.ThreadState, 
                                          TotalProcessorTime = safeTotalProcessorTime(t),  
                                      } 
                                  ).ToList();
                    var totalCpuMsecs = threads.Sum(t => t.TotalProcessorTime);
                    var topThread = threads[0];
                    var nextThread = threads[1];
                    var topThreadCpuMsecs = topThread.TotalProcessorTime;
                    var topThreadRatio = topThreadCpuMsecs / nextThread.TotalProcessorTime;
    
                    // suspend skype thread that's taken a lot of CPU time and 
                    // and it has lots more CPU than any other thread. 
                    // in other words, it's been ill-behaved for a long time!
                    // it's possible that this may sometimes suspend the wrong thread, 
                    // but I haven't seen it break yet. 
                    if (topThreadCpuMsecs > 10000 && topThreadRatio > 5)
                    {
                        Console.WriteLine("{0} bad thread. {0:N0} msecs CPU, {1:N1}x CPU than next top thread.",
                            topThread.ThreadState == System.Diagnostics.ThreadState.Wait ? "Already suspended" : "Suspending",
                            topThreadCpuMsecs, 
                            topThreadRatio);
                        Thread.Sleep(1000);
    
                        IntPtr handle = IntPtr.Zero;
                        try
                        {
                            //Get the thread handle & suspend the thread
                            handle = OpenThread(2, false, topThread.Id);
                            var success = SuspendThread(handle);
                            if (success == -1)
                            {
                                Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("Exiting");
                            Thread.Sleep(1000);
                            return;
                        }
                        finally
                        {
                            if (handle != IntPtr.Zero)
                                CloseHandle(handle);
                        };
                    }
    
                    Console.WriteLine("Top thread: {0:N0} msecs CPU, {1:N1}x CPU than next top thread. Waiting.",
                        topThreadCpuMsecs,
                        topThreadRatio);
    
                    Thread.Sleep(2000); // wait between tries
                }
                Console.WriteLine("No skype thread is ill-behaved enough. Giving up.");
            }
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern int SuspendThread(IntPtr hThread);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr handle);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern
            IntPtr OpenThread(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)]bool bInheritHandle, int dwThreadId);
        }
    }
