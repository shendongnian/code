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
            try
            {
                action();
            }
            catch ( Exception exception )
            {
    #if DEBUGGING
                throw;
    #endif
                this.exception = exception;
            }
            return this;
        }
        [DebuggerStepThrough]
        public DangerousOperation Catch<TException>(Action<TException> action, bool throwIfUnhandled = true)
        {
            if ( exception == null || handled )
            {
                return this;
            }
            if ( action != null && typeof(TException).IsAssignableFrom(exception.GetType()) )
            {
                action((TException) (object) exception);
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
