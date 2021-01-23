    public static Task<TResult> WrapExceptions<TResult>(this Task<TResult> task, params Type[] exceptionTypes)
    {
        return task.ContinueWith(_ =>
        {
            if (_.Status == TaskStatus.RanToCompletion) return _.Result;
            if (_.Exception.InnerExceptions.Count > 1)
            {
                throw new AggregateException(_.Exception);
            }
            var innerException = _.Exception.InnerExceptions[0];
            if (exceptionTypes.Contains(innerException.GetType()))
            {
                throw new ServiceWrapperException("Some Context", innerException);
            }
            throw _.Exception;
        });
    }
