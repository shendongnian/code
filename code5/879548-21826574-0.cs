    public static class DelegateExtensions
    {
        public static TResult EndInvoke<TDelegate, TResult>(this TDelegate asyncCaller, IAsyncResult asyncResult) where TDelegate : System.Delegate
        {
            TResult result = default(TResult);
            try
            {
                result = asyncCaller.EndInvoke(asyncResult);
            }
            catch ( Exception ex)
            {
                LogExceptionMessageOrWhatever(ex.Message);
                throw;
            }
            return result;
        }
    }
