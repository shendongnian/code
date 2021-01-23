    public static async Task<bool> LogicalAny(this IEnumerable<Task<bool>> tasks)
    {
        var remainingTasks = new HashSet<Task<bool>>(tasks);
        while (remainingTasks.Any())
        {
            var next = await Task.WhenAny(remainingTasks);
            if (next.Result)
                return true;
            remainingTasks.Remove(next);
        }
        return false;
    }
