    public class TryResult<TResult>
    {
        bool Failure { get; set; }
        TResult Result { get; set; }
        Exception Exception { get; set; }
    }
    public static TResult Try<TResult>(Action<TResult> action)
    {
        var result = new TryResult<TResult>();
        try
        {
            result.Result = action();
        }
        catch (Exception ex)
        {
            result.Exception = ex;
            result.Failure = true;
        }
    }
