    private ConcurrentQueue<ActionFileAction> _actionFileQueue = new ConcurrentQueue<ActionFileAction>();
            internal ActionFileAction GetNextFreeAction(CancellationToken cancellationToken = default(CancellationToken))
            {
                // Checks if a cancellation was requested
                cancellationToken.ThrowIfCancellationRequested();
                ActionFileAction actionFileToHandle;
                _actionFileQueue.TryDequeue(out actionFileToHandle);
    
                //may return null if couldn't dequeue
                return actionFileToHandle;
            }
    
            //C# Methods should be CamelCase without underscores
            void HandleAllActionFiles()
            {
                try
                {
                    var cancellationToken = new CancellationTokenSource().Token;
                    Parallel.Invoke(
                        new ParallelOptions
                        {
                            MaxDegreeOfParallelism = Environment.ProcessorCount,
                            CancellationToken = cancellationToken
                        }, () => GetNextFreeAction());
                }
                catch (OperationCanceledException e)
                {
                    // Do stuff with cancellation
                }
            }
