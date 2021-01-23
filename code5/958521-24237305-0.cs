    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Test
    {
        static void Main(string[] args)
        {
            // Not using Task.Delay! That would be pointless
            Task t1 = new Task(() => Thread.Sleep(1000));
            Task t2 = Await(t1);
            Console.WriteLine(t2.Status);
            Console.WriteLine("Starting original task");
            t1.Start(); 
            Console.WriteLine(t2.Status);
            t2.Wait();
            Console.WriteLine(t2.Status);        
        }
        
        static async Task Await(Task task)
        {
            Console.WriteLine("Beginning awaiting");
            await task;
            Console.WriteLine("Finished awaiting");        
        }
    }
