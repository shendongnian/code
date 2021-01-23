    private void ConnectCallback()
    {
      LazyAsyncResult asyncResult = (LazyAsyncResult) m_AcceptQueueOrConnectResult;
      
      // If we came here due to a ---- between BeginConnect and Dispose
      if (asyncResult.InternalPeekCompleted)
      {
         // etc.
          return;
      }
    }
