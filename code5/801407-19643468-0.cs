    public class DataBaseOptions : IDisposable
    {
        public DataBaseOptions()
        {
            // save initial state here
        }
        public DataBaseOptions OptimisticConcurrency( bool state )
        {
            // set option state
            return this ;
        }
        public DataBaseOptions IsolationLevel( IsolationLevel state )
        {
            // set option state
            return this ;
        }
        public void Dispose()
        {
            // restore initial state here ;
        }
    }
    
    public enum IsolationLevel
    {
        ReadCommitted   = 0 ,
        ReadUncommitted = 1 ,
        CursorStability = 2 ,
        // etc.
    }
