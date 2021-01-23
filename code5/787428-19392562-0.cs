    try
    {
      this.m_rootTask.Wait();
    }
    catch (AggregateException ex)
    {
      AggregateException aggregateException = ex.Flatten();
      bool cacellation = true;
      for (int i = 0; i < aggregateException.InnerExceptions.Count; ++i)
      {
        var canceledException =
            aggregateException.InnerExceptions[i] as OperationCanceledException;
        if (IsCancellation(canceledException))
        {
          cacellation = false;
          break;
        }
      }
      if (!cacellation)
        throw aggregateException;
    }
    finally
    {
      this.m_rootTask.Dispose();
    }
    if (!this.m_cancellationState.MergedCancellationToken.IsCancellationRequested)
      return;
    if (!this.m_cancellationState.TopLevelDisposedFlag.Value)
      CancellationState.ThrowWithStandardMessageIfCanceled(
        this.m_cancellationState.ExternalCancellationToken);
    if (!userInitiatedDispose)
      throw new ObjectDisposedException(
        "enumerator", "The query enumerator has been disposed.");
