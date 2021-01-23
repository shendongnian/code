        public class DangerousOperation
        {
            [DebuggerStepThrough]
            public void Try<TException>(Action action, Action<TException> Catch = null, Action Finally = null) where TException : Exception
            {
                try
                {
                    action();
                }
                catch ( TException exception )
                {
                    if ( Catch == null )
                    {
                        throw;
                    }
    #if DEBUGGING
                    throw;
    #endif
                    Catch(exception);
                }
                finally
                {
                    if ( Finally != null )
                    {
                        Finally();
                    }
                }
            }
        }
