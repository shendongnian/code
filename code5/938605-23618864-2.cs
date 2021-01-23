    public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout)
    {
        if (task != await Task.WhenAny(task, Task.Delay(timeout)))
        {
            throw new TimeoutException();
        }
        return task.Result; // Task is guaranteed completed (WhenAny), so this won't block
    }
