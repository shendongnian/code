    static OutputDataType Foo(InputDataType data)
    {
        var cts = new CancellationTokenSource();
        var task1 = Task.Factory.StartNew(() => RunFunc1(data, cts.Token));
        var task2 = Task.Factory.StartNew(() => RunFunc2(data, cts.Token));
        var task3 = Task.Factory.StartNew(() => RunFunc3(data, cts.Token));
        var tasks = new [] { task1, task2, task3 };
        while (tasks.Any())
        {
            // Wait for any task to complete.
            int completedIndex = Task.WaitAny(tasks);
            var completedTask = tasks[completedIndex];
            // If its result is good, indicate cancellation to the other tasks,
            // and return the result.
            if (IsResultGood(completedTask.Result))
            {
                cts.Cancel();
                return completedTask.Result;
            }
            // Otherwise, remove the completed task from the array,
            // and proceed to the next iteration.
            tasks = tasks.Where((t, i) => i != completedIndex).ToArray();
        }
        return null;
    }
