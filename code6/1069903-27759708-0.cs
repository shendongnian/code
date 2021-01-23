    public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeSpan, string message = null)
    {
        if(task.Status != TaskStatus.Running && task.Status != TaskStatus.RanToCompletion){
           task.Start();
        }
        if (task == await Task.WhenAny(task, Task.Delay(timeSpan)))
           return await task;
        else
        {
            throw new TimeoutException(message);
        }
    }
