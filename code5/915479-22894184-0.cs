    public static IPropagatorBlock<TInput, TOutput>
        CreateUnorderedTransformBlock<TInput, TOutput>(
        Func<TInput, TOutput> func, ExecutionDataflowBlockOptions options)
    {
        var buffer = new BufferBlock<TOutput>(options);
        var action = new ActionBlock<TInput>(
            async input =>
            {
                var output = func(input);
                await buffer.SendAsync(output);
            }, options);
        action.Completion.ContinueWith(
            t =>
            {
                IDataflowBlock castedBuffer = buffer;
                if (t.IsFaulted)
                {
                    castedBuffer.Fault(t.Exception);
                }
                else if (t.IsCanceled)
                {
                    // do nothing: both blocks share options,
                    // which means they also share CancellationToken
                }
                else
                {
                    castedBuffer.Complete();
                }
            });
        return DataflowBlock.Encapsulate(action, buffer);
    }
