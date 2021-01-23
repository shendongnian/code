    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static int ComGetMessage()
            {
                NativeMethods.SleepEx(2000, true);
                return 42;
            }
    
            static int GetMessage(CancellationToken token)
            {
                var apcWasCalled = false;
                var apcCallback = new NativeMethods.APCProc(target => 
                    apcWasCalled = true);
    
                var hCurThread = NativeMethods.GetCurrentThread();
                var hCurProcess = NativeMethods.GetCurrentProcess();
                IntPtr hThread;
                if (!NativeMethods.DuplicateHandle(hCurProcess, hCurThread, hCurProcess, out hThread, 
                    0, false, NativeMethods.DUPLICATE_SAME_ACCESS))
                {
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                }
                try
                {
                    int result;
                    using (token.Register(
                        () => NativeMethods.QueueUserAPC(apcCallback, hThread, UIntPtr.Zero),
                        useSynchronizationContext: false))
                    {
                        result = ComGetMessage();
                    }
                    Trace.WriteLine(new { apcWasCalled });
                    token.ThrowIfCancellationRequested();
                    return result;
                }
                finally
                {
                    NativeMethods.CloseHandle(hThread);
                }
            }
    
            static async Task TestAsync(int delay)
            {
                var cts = new CancellationTokenSource(delay);
                try
                {
                    var result = await Task.Run(() => GetMessage(cts.Token));
                    Console.WriteLine(new { result });
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Cancelled.");
                }
            }
    
            static void Main(string[] args)
            {
                TestAsync(3000).Wait();
                TestAsync(1000).Wait();
            }
    
            static class NativeMethods
            {
                public delegate void APCProc(UIntPtr dwParam);
    
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern uint SleepEx(uint dwMilliseconds, bool bAlertable);
    
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern uint QueueUserAPC(APCProc pfnAPC, IntPtr hThread, UIntPtr dwData);
    
                [DllImport("kernel32.dll")]
                public static extern IntPtr GetCurrentThread();
    
                [DllImport("kernel32.dll")]
                public static extern IntPtr GetCurrentProcess();
    
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern bool CloseHandle(IntPtr handle);
    
                public const uint DUPLICATE_SAME_ACCESS = 2;
    
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern bool DuplicateHandle(IntPtr hSourceProcessHandle,
                   IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle,
                   uint dwDesiredAccess, bool bInheritHandle, uint dwOptions);
            }
        }
    }
