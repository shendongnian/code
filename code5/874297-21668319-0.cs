    public static async Task WhenN(IEnumerable<Task> tasks, int n, CancellationTokenSource cts = null)
    {
        var pending = new HashSet<Task>(tasks);
    
        if (n > pending.Count)
        {
            n = pending.Count;
    
            // or throw
        }
    
        var completed = 0;
    
        while (completed != n)
        {
            var completedTask = await Task.WhenAny(pending);
    
            pending.Remove(completedTask);
    
            completed++;
        }
            
        if (cts != null)
        {
            cts.Cancel();
        }
    }
