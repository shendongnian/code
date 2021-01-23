    using System;
    using Mono.Unix.Native;
    namespace StackOverflow
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                int pid = Syscall.getpid();
                int ppid = Syscall.getppid();
                Console.WriteLine ("PID: {0}", pid);
                Console.WriteLine ("PPID: {0}", ppid);
            }
        }
    }
