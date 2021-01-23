    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task>();
    
            for (var i = 0; i < 100; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => SomeMethod(i)).Unwrap());
            }
    
            Task.WaitAll(tasks.ToArray());
    
            Console.WriteLine("Enter to exit...");
            Console.ReadLine();
        }
    
        private static Task<Task[]> SomeMethod(int n)
        {
            Console.WriteLine("SomeMethod " + n);
    
            var numbers = new List<int>();
    
            for (var i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }
    
            var tasks = new List<Task>();
    
            foreach (var number in numbers)
            {
                Console.WriteLine("Before start task " + number);
    
                var numberSafe = number;
    
                var nextTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Got number: {0}", numberSafe);
                })
                .ContinueWith(task =>
                {
                    Console.WriteLine("Continuation {0}", task.Id);
                }, TaskContinuationOptions.ExecuteSynchronously);
    
                tasks.Add(nextTask);
            }
    
            return Task.Factory.ContinueWhenAll(tasks.ToArray(), 
                result => result, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
