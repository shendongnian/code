    public static ITargetBlock<T> CreateGuaranteedBroadcastBlock<T>(
        IEnumerable<ITargetBlock<T>> targets, DataflowBlockOptions options)
    {
        var targetsList = targets.ToList();
    
        var block = new ActionBlock<T>(
            async item =>
            {
                foreach (var target in targetsList)
                {
                    await target.SendAsync(item);
                }
            }, new ExecutionDataflowBlockOptions
            {
                BoundedCapacity = options.BoundedCapacity,
                CancellationToken = options.CancellationToken
            });
        block.Completion.ContinueWith(task =>
        {
            foreach (var target in targetsList)
            {
                if (task.Exception != null)
                    target.Fault(task.Exception);
                else
                    target.Complete();
            }
        });
        return block;
    }
