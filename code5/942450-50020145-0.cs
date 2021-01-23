    using System;
    using System.Diagnostics;
    using System.Threading;
    using Microsoft.Win32.SafeHandles;
    using static System.FormattableString;
    public class ProcessWaitHandle : WaitHandle
    {
        public ProcessWaitHandle(Process process) =>
            this.SafeWaitHandle = new SafeWaitHandle(process.Handle, false);
    }
    class Program
    {
        static void Main(string[] args)
        {
            int processesCount = 42;
            var processes = new Process[processesCount];
            var waitHandles = new WaitHandle[processesCount];
            try
            {
                for (int i = 0; processesCount > i; ++i)
                {
                    // exit immediately with return code i
                    Process process = Process.Start(
                        "cmd.exe",
                        Invariant($"/C \"exit {i}\""));
                    processes[i] = process;
                    waitHandles[i] = new ProcessWaitHandle(process);
                }
                WaitHandle.WaitAll(waitHandles);
                foreach (Process p in processes)
                {
                    Console.Error.WriteLine(
                        Invariant($"process with Id {p.Id} exited with code {p.ExitCode}"));
                }
            }
            finally
            {
                foreach (Process p in processes)
                {
                    p?.Dispose();
                }
                foreach (WaitHandle h in waitHandles)
                {
                    h?.Dispose();
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(false);
        }
    }
