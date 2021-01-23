    private readonly CycleExecutedAwaiter _awaiter = new CycleExecutedAwaiter();
    
            public Awaiter CycleExecutedEvent()
            {
                if (!IsRunning) throw new TaskCanceledException("Simulation has been stopped");
                return _awaiter;
            }
    
            private sealed class CycleExecutedAwaiter : Awaiter
            {
                public override void GetResult()
                {
                    var syncContext = SynchronizationContext.Current as ScriptingSynchronizationContext;
                    if (syncContext != null && syncContext.StopRequested)
                        throw new TaskCanceledException("Stop Requested");
                }
            }
