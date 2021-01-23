    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Test
    {
        static void Main()
        {
            // Make sure DemonstrateIssue is already called in a ThreadPool
            // thread...
            Task task = Task.Run((Action) DemonstrateIssue);
            task.Wait();
        }
        
        static void DemonstrateIssue()
        {
            Console.WriteLine("DemonstrateIssue thread: {0}",
                              Thread.CurrentThread.ManagedThreadId);
            Action action = () => Console.WriteLine("Inner task thread: {0}",
                Thread.CurrentThread.ManagedThreadId);
            Task task = new Task(action);
            // Calling Start will just schedule it... we may be able to Wait
            // before it actually executed
            task.Start();
            task.Wait();
        }
    }
