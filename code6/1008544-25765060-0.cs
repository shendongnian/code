    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            var taskList = new List<Task<int>>
            {
                Task<int>.Factory.StartNew(Method1),
                Task<int>.Factory.StartNew(Method2)
            }.ToArray();
            Task.WaitAll(taskList);
            foreach (var task in taskList)
            {
                Console.WriteLine(task.Result);
            }
            Console.ReadLine();
        }
        private static int Method2()
        {
            return 2;
        }
        private static int Method1()
        {
            return 1;
        }
    }
