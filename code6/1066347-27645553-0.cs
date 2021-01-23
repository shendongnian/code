    public static class ExceptionExtensions
    {
        public static void Trace(this Exception _this)
        {
            Trace.TraceError("{0:HH:mm:ss.fff} Exception {1}", DateTime.Now, _this);
        }
    }
