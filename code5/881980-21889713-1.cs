    public async Task<TResult> Invoke<TResult>(Func<FutClient, Task<TResult>> func, object requestDetails = null,
        [CallerMemberName] string exceptionMessage = null)
    {
        try
        {
            if (LastException + new TimeSpan(0, 0, 30) < DateTime.Now)
            {
                TResult result = await func(_futClient).ConfigureAwait(false); //Here we both await for the result and set `ConfigureAwait` to false so we don't need to waist extra time trying to marshal back on to the original Synchronization context as we have no need for it for the rest of the method.
                return result;
            }
        }
        catch (Exception e)
        {
            //...
