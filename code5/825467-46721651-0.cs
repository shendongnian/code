    using Nito.AsyncEx;
    using System;
    using System.Threading.Tasks;
    
    class Program
    {
        // Use a single-threaded SynchronizationContext similar to winforms/WPF
        static void Main(string[] args) => AsyncContext.Run(() => RunAsync());
    
        static async Task RunAsync()
        {
            Task<Task> task = null;
            task = getOwnTaskAsync();
            var foundTask = await task;
            Console.WriteLine($"{task?.Id} == {foundTask?.Id}: {task == foundTask}");
    
            async Task<Task> getOwnTaskAsync()
            {
                // Cause this method to return and let the 「task」 local be assigned.
                await Task.Yield();
                return task;
            }
        }
    }
