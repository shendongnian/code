        /// <summary>
        /// Waits for the task to complete, for a timeout to occur, or for cancellation to be requested.
        /// The method first spins and then falls back to blocking on a new event.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout.</param>
        /// <param name="cancellationToken">The token.</param>
        /// <returns>true if the task is completed; otherwise, false.</returns>
        private bool SpinThenBlockingWait(int millisecondsTimeout, CancellationToken cancellationToken)
        {
            bool infiniteWait = millisecondsTimeout == Timeout.Infinite;
            uint startTimeTicks = infiniteWait ? 0 : (uint)Environment.TickCount;
            bool returnValue = SpinWait(millisecondsTimeout);
            if (!returnValue)
            {
                var mres = new SetOnInvokeMres();
                try
                {
                    AddCompletionAction(mres, addBeforeOthers: true);
                    if (infiniteWait)
                    {
                        returnValue = mres.Wait(Timeout.Infinite, cancellationToken);
                    }
                    else
                    {
                        uint elapsedTimeTicks = ((uint)Environment.TickCount) - startTimeTicks;
                        if (elapsedTimeTicks < millisecondsTimeout)
                        {
                            returnValue = mres.Wait((int)(millisecondsTimeout - elapsedTimeTicks), cancellationToken);
                        }
                    }
                }
                finally
                {
                    if (!IsCompleted) RemoveContinuation(mres);
                    // Don't Dispose of the MRES, because the continuation off of this task may
                    // still be running.  This is ok, however, as we never access the MRES' WaitHandle,
                    // and thus no finalizable resources are actually allocated.
                }
            }
            return returnValue;
        }
 
