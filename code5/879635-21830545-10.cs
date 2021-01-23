    public class DangerousOperation
    {
        private Exception exception;
        private bool handled = false;
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
        public DangerousOperation Catch<TException>(Action<TException> action)
        {
            if ( handled )
            {
                return this;
            }
            if ( action != null && exception != null )
            {
                if ( typeof(TException).IsAssignableFrom(exception.GetType()) )
                {
                    action((TException) (object) exception);
                    handled = true;
                }
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
