    this.mSubscriptionClient.OnMessage(
                 (pMessage) =>
                 {
                     try
                     {
                         // Will block the current thread if Stop is called.
                         this.mPauseProcessingEvent.WaitOne();
                         // Execute processing task here
                         pProcessMessageTask(pMessage);
                     }
                     catch(Exception ex)
                     {
                         this.RaiseOnLogMessageEvent(pMessage, ex);
                     }
                 },
                 options);
