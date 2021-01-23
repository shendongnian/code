    using System;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ParrellelEachExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var indexes = new int[] { 1, 2, 3 };
    
                RunExample((prefix) => Parallel.ForEach(indexes, (i) => DoSomethingAsync(i, prefix)),
                    "Parallel.Foreach");
    
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*You'll notice the tasks haven't run yet, because the main thread was not blocked*");
                Console.WriteLine("Press any key to start the next example...");
                Console.ReadKey();
                
                RunExample((prefix) => Task.WhenAll(indexes.Select(i => DoSomethingAsync(i, prefix)).ToArray()).Wait(),
                    "Task.WhenAll");
                Console.WriteLine("All tasks are done.  Press any key to close...");
                Console.ReadKey();
            }
    
            static void RunExample(Action<string> action, string prefix)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{Environment.NewLine}Starting '{prefix}'...");
                action(prefix);
                Console.WriteLine($"{Environment.NewLine}Finished '{prefix}'{Environment.NewLine}");
            }
            
    
            static async Task DoSomethingAsync(int i, string prefix)
            {
                await Task.Delay(i * 1000);
                Console.WriteLine($"Finished: {prefix}[{i}]");
            }
        }
    }
