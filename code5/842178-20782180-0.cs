      if (ct.IsCancellationRequested)
        {
            Console.WriteLine("[{0}] - Task - [{1}]:  Cancellation Requested", TimeSpan.FromTicks(DateTime.Now.Ticks - whenStarted.Ticks), taskId);
            throw new OperationCanceledException(ct);
        }
