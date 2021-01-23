    public GetDataOperationResult<TResult> TryGet<TResult>(Func<TResult> function, int maximumRetryCount, string successText, string undeterminedErrorText)
    {
        Debug.Assert(function != null, "The function input parameter of the DataOperationManager.TryGet<TResult>() method must not be null.");
        for (int index = 0; index < maximumRetryCount; index++)
        {
            try
            {
                TResult result = function();
                return new GetDataOperationResult<TResult>(result, successText, undeterminedErrorText);
            }
            catch (Exception exception)
            {
                if (index == maximumRetryCount - 1) return new GetDataOperationResult<TResult>(exception, successText, undeterminedErrorText);
                int sleepCount = GetSleepTime(index, minimumDelay);
                Thread.Sleep(sleepCount);
            }
        } 
        return new GetDataOperationResult<TResult>(default(TResult), successText, undeterminedErrorText);
    }
