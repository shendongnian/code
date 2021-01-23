    public delegate TFooResult GetFooAsync<TFooResult>();
    public static class GetFooAsyncExtensions
    {
        public static TFooResult EndInvoke<TFooResult>(this GetFooAsync<TFooResult> asyncCaller, IAsyncResult asyncResult)
        {
            TFooResult result = default(TFooResult);
            try
            {
                result = asyncCaller.EndInvoke(asyncResult);
            }
            catch ( Exception ex )
            {
                throw;
            }
            return result;
        }
    }
