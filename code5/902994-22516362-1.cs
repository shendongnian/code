        void ReturnResponseAfterAShortDelay(WaitHandle cancellationToken)
        {
            log.InfoFormat("Deferring response for {0} ms", Settings.Default.TimeoutMs);
            ThreadPool.RegisterWaitForSingleObject(cancellationToken, 
                () => 
                {
                    if (!cancellationToken.WaitOne(0))
                    {
                        ReturnWhateverHasArrived();
                    }
                }, 
                null, Settings.Default.TimeoutMs, true);
        }
