    public class DangerousOperation
    {
        private Exception exception;
        private bool handled;
        public DangerousOperation()
        {
            handled = false;
        }
        [DebuggerStepThrough]
        public DangerousOperation Try(Action action)
        {
    #if DEBUGGING
            action();
    #else
            try
            {
                action();
            }
            catch ( Exception exception )
            {
                this.exception = exception;
            }
    #endif
            return this;
        }
        [DebuggerStepThrough]
        public DangerousOperation Catch<TException>(Action<TException> action, bool throwIfUnhandled = true) where TException : Exception
        {
            if ( exception == null || handled )
            {
                return this;
            }
            if ( typeof(TException).IsAssignableFrom(exception.GetType()) )
            {
                if ( action != null )
                {
                    action((TException) exception);
                }
                handled = true;
            }
            if ( !handled && throwIfUnhandled )
            {
                throw exception;
            }
            return this;
        }
        [DebuggerStepThrough]
        public void Finally(Action action)
        {
            action();
            if ( !handled && exception != null )
            {
                throw exception;
            }
        }
    }
