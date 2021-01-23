    public static async Task<IEnumerable<TResult>> WhenAllSwallowExceptions<TResult>(IEnumerable<Task<TResult>> tasks)
    {
        var tasklist = tasks.ToList();
        var results = new List<TResult>();
        while (tasklist.Any())
        {
            var completedTask = await Task.WhenAny(tasklist);
            try
            {
                results.Add(await completedTask);
            }
            catch (Exception e)
            {
                // handle
            }
            tasklist.Remove(completedTask);
        }
        return results;
    }
