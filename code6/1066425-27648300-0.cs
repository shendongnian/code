    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DoTasks();
                Console.Write("Press any key");
                Console.ReadKey();
            }
            static void DoTasks(int count = 1)
            {
                bool output;
                int timeout = 1000;
                Task<bool> task = test(count);
                if (Task.WaitAny(new Task<bool>[] {task}, timeout) == 0)
                {
                    Console.WriteLine("succeed #" + count);
                    output = task.Result;
                }
                else
                {
                    Console.WriteLine("try #" + count);
                    DoTasks(++count);
                }
            }
            async static Task<bool> test(int count)
            {
                int sleep = 2000 - (count * 200);
                await Task.Run(() => Thread.Sleep(sleep));
                return true;
            }
        }
    }
