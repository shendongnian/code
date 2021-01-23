c#
public static Task WaitUntil<T>(T elem, Func<T, bool> predicate, int seconds = 10)
{
    var tcs = new TaskCompletionSource<int>();
    using(var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(seconds)))
    {
        cancellationTokenSource.Token.Register(() =>
        {
            tcs.SetException(
                new TimeoutException($"Waiting predicate {predicate} for {elem.GetType()} timed out!"));
            tcs.TrySetCanceled();
        });
        while(!cancellationTokenSource.IsCancellationRequested)
        {
            try
            {
                if (!predicate(elem))
                {
                    continue;
                }
            }
            catch(Exception e)
            {
                tcs.TrySetException(e);
            }
            tcs.SetResult(0);
            break;
        }
        return tcs.Task;
    }
}
