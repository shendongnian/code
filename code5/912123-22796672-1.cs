    // Request the lock. 
    if (Monitor.TryEnter(m_inputQueue, waitTime))
    {
       try
       {
          m_inputQueue.Enqueue(qValue);
       }
       finally
       {
          // Ensure that the lock is released.
          Monitor.Exit(m_inputQueue);
       }
       return true;
    }
    else
    {
       return false;
    }
