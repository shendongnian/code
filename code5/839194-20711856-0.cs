    public static ITargetBlock<T> CreateBatchingWrapper<T>(
    ITargetBlock<IReadOnlyList<T>> target)
    {
        // target should have BoundedCapacity == 1,
        // but there is no way to check for that
        var source = new BufferBlock<T>();
        Task.Run(() => BatchItems(source, target));
        return source;
    }
    private static async Task BatchItems<T>(
        IReceivableSourceBlock<T> source, ITargetBlock<IReadOnlyList<T>> target)
    {
        try
        {
            while (true)
            {
                var messages = new List<T>();
                // wait for first message in batch
                if (!await source.OutputAvailableAsync())
                {
                    // source was completed, complete target and return
                    target.Complete();
                    return;
                }
                // receive all there is right now
                source.ReceiveAllInto(messages);
                // try sending what we've got
                var sendCancellation = new CancellationTokenSource();
                var sendTask = target.SendAsync(messages, sendCancellation.Token);
                var outputAvailableTask = source.OutputAvailableAsync();
                while (true)
                {
                    await Task.WhenAny(sendTask, outputAvailableTask);
                    // got another message, try cancelling send
                    if (outputAvailableTask.IsCompleted
                        && outputAvailableTask.Result)
                    {
                        sendCancellation.Cancel();
                        // cancellation wasn't successful
                        // and the message was received, start another batch
                        if (!await sendTask.EnsureCancelled() && sendTask.Result)
                            break;
                        // send was cancelled, receive messages
                        source.ReceiveAllInto(messages);
                        // restart both Tasks
                        sendCancellation = new CancellationTokenSource();
                        sendTask = target.SendAsync(
                            messages, sendCancellation.Token);
                        outputAvailableTask = source.OutputAvailableAsync();
                    }
                    else
                    {
                        // we get here in three situations:
                        // 1. send was completed succesfully
                        // 2. send failed
                        // 3. input has completed
                        // in cases 2 and 3, this await is necessary
                        // in case 1, it's harmless
                        await sendTask;
                        break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            source.Fault(e);
            target.Fault(e);
        }
    }
    /// <summary>
    /// Returns a Task that completes when the given Task completes.
    /// The Result is true if the Task was cancelled,
    /// and false if it completed successfully.
    /// If the Task was faulted, the returned Task is faulted too.
    /// </summary>
    public static Task<bool> EnsureCancelled(this Task task)
    {
        return task.ContinueWith(t =>
        {
            if (t.IsCanceled)
                return true;
            if (t.IsFaulted)
            {
                // rethrow the exception
                ExceptionDispatchInfo.Capture(task.Exception.InnerException)
                    .Throw();
            }
            // completed successfully
            return false;
        });
    }
    public static void ReceiveAllInto<T>(
        this IReceivableSourceBlock<T> source, List<T> targetCollection)
    {
        // TryReceiveAll would be best suited for this, except it's bugged
        // (see http://connect.microsoft.com/VisualStudio/feedback/details/785185)
        T item;
        while (source.TryReceive(out item))
            targetCollection.Add(item);
    }
