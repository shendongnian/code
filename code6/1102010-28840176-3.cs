    static void Main()
    {
        InputDataType data = getMyData();
        OutputDataType x = Foo(data).Result;
    }   
    static async Task<OutputDataType> Foo(InputDataType data)
    {
        // Spawn your tasks, passing the cancellation token.
        var cts = new CancellationTokenSource();
        var task1 = Task.Factory.StartNew(() => RunFunc1(data, cts.Token));
        var task2 = Task.Factory.StartNew(() => RunFunc2(data, cts.Token));
        var task3 = Task.Factory.StartNew(() => RunFunc3(data, cts.Token));
        var tasks = new [] { task1, task2, task3 };
        // Loop while tasks are running.
        while (tasks.Any())
        {
            // Wait for any task to complete.
            var completedTask = await Task.WhenAny(tasks);
            // If its result is good, indicate cancellation to the other tasks,
            // and return the result.
            if (IsResultGood(completedTask.Result))
            {
                cts.Cancel();
                return completedTask.Result;
            }
            // Otherwise, remove the completed task from the array,
            // and proceed to the next iteration.
            tasks = tasks.Where(t => t != completedTask).ToArray();
        }
        // No good results.
        return null;
    }
