    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace UnobservedTaskException
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine("Runtime Version: {0}", Environment.Version);
    
                var task = Task.Factory.StartNew<int>(() =>
                {
                    throw new Exception("Calculation in task failed");
                });
    
                while (!task.IsFaulted)
                {
                    Thread.Sleep(1);
                }
    
                task = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
