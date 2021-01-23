    List<Task<int>> tasks = new List<Task<int>> ();
    for (int i = 0; i < 4; i++)
        tasks.Add (Task.Run (() => LongRunningComputation ()));
    Task<int[]> allCompleted = Task.WhenAll (tasks);
    Task jobDone = allCompleted.ContinueWith (
        aggregateTask => MessageBox.Show ("And the result is: " + aggregateTask.Result.Sum ()));
    return jobDone;
