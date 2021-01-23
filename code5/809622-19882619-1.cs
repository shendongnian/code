    /// <summary>Propagates any exceptions that occurred on the specified tasks.</summary>
    /// <param name="tasks">The Task instances whose exceptions are to be propagated.</param>
    public static void PropagateExceptions(this Task [] tasks)
    {
        if (tasks == null) throw new ArgumentNullException("tasks");
        if (tasks.Any(t => t == null)) throw new ArgumentException("tasks");
        if (tasks.Any(t => !t.IsCompleted)) throw new InvalidOperationException("A task has not completed.");
        Task.WaitAll(tasks);
    }
