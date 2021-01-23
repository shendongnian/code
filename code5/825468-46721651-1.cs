    using System;
    using System.Threading.Tasks;
    
    class Program
    {
        // Fully free-threaded! Works in more environments!
        static void Main(string[] args) => RunAsync().Wait();
    
        static async Task RunAsync()
        {
            var ownTaskSource = new TaskCompletionSource<Task>();
            var task = getOwnTaskAsync(ownTaskSource.Task);
            ownTaskSource.SetResult(task);
            var foundTask = await task;
            Console.WriteLine($"{task?.Id} == {foundTask?.Id}: {task == foundTask}");
    
            async Task<Task> getOwnTaskAsync(
                Task<Task> ownTaskTask)
            {
                // This might be clearer.
                return await ownTaskTask;
            }
        }
    }
