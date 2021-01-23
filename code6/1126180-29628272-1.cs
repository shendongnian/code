    using System.Threading.Tasks;
    using System.Threading;
    
        class Program
        {
            static void Main(string[] args)
            {
                Task task1 = Task.Factory.StartNew(() => doStuff("Task1"));
                Task task2 = Task.Factory.StartNew(() => doStuff("Task2"));
                Task task3 = Task.Factory.StartNew(() => doStuff("Task3"));
                Task.WaitAll(task1, task2, task3);
    
                Console.WriteLine("All threads complete");
                Console.ReadLine();
            }
    
            static void doStuff(string strName)
            {
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine(strName + " " + i.ToString());
                    Thread.Yield();
                }
            }
        }
