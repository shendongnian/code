    Task aggregateTask = Task.Factory.ContinueWhenAll(
        Batch,
        TaskExtrasExtensions.PropagateExceptions,
        TaskContinuationOptions.ExecuteSynchronously);
    aggregateTask.Wait();
