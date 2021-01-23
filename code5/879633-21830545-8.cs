        public class DangerousOperation<TException> : IDisposable where TException : Exception
        {
            public Action Try { get; set; }
            public Action<TException> Catch { get; set; }
            public void Dispose()
            {
    #if DEBUGGING
                this.Try();
    #else
                try
                {
                    this.Try();
                }
                catch ( TException ex )
                {
                    this.Catch(ex);
                }
    #endif
            }
        }
