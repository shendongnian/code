    /// <remarks>
    /// boundedCapacity represents the capacity of the input queue
    /// and the output queue separately, not their total.
    /// </remarks>
    public static IPropagatorBlock<TInput, TOutput>
        CreateBoundedTransformManyBlock<TInput, TOutput>(
        Func<TInput, IEnumerable<TOutput>> transform, int boundedCapacity)
    {
        var input = new BufferBlock<TInput>(
            new DataflowBlockOptions { BoundedCapacity = boundedCapacity });
        var output = new BufferBlock<TOutput>(
            new DataflowBlockOptions { BoundedCapacity = boundedCapacity });
        Task.Run(
            async () =>
            {
                try
                {
                    while (await input.OutputAvailableAsync())
                    {
                        var data = transform(await input.ReceiveAsync());
                        await output.SendAllAsync(data);
                    }
                    output.Complete();
                }
                catch (Exception e)
                {
                    ((IDataflowBlock)input).Fault(e);
                    ((IDataflowBlock)output).Fault(e);
                }
            });
        return DataflowBlock.Encapsulate(input, output);
    }
