    public static class Retries
    {
        public enum Result
        {
            Success,
            Timeout, 
            Canceled,
        }
        public static Task<Result> RetryUntilTimedOutOrCanceled(this Func<bool> func, CancellationToken cancel, TimeSpan timeOut)
        {
            return Task.Factory.StartNew(() =>
            {
                var start = DateTime.UtcNow;
                var end = start + timeOut;
                while (true)
                {
                    var now = DateTime.UtcNow;
                    if (end < now)
                        return Result.Timeout;
                    var curTimeOut = end - now;
                    Task<bool> curTask = null;
                    try
                    {
                        if (cancel.IsCancellationRequested)
                            return Result.Canceled;
                        curTask = Task.Factory.StartNew(func, cancel);
                        curTask.Wait((int)curTimeOut.TotalMilliseconds, cancel);
                        if (curTask.IsCanceled)
                            return Result.Canceled;
                        if (curTask.Result == true)
                            return Result.Success;
                    }
                    catch (TimeoutException)
                    {
                        return Result.Timeout;
                    }
                    catch (TaskCanceledException)
                    {
                        return Result.Canceled;
                    }
                    catch (OperationCanceledException)
                    {
                        return Result.Canceled;
                    }
                }
            });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cancelSource = new CancellationTokenSource();
            Func<bool> AllwaysFalse = () => false;
            Func<bool> AllwaysTrue = () => true;
            var result = AllwaysFalse.RetryUntilTimedOutOrCanceled(cancelSource.Token, TimeSpan.FromSeconds(3)).Result;
            Console.WriteLine(result);
            result = AllwaysTrue.RetryUntilTimedOutOrCanceled(cancelSource.Token, TimeSpan.FromSeconds(3)).Result;
            Console.WriteLine(result);
            var rTask = AllwaysFalse.RetryUntilTimedOutOrCanceled(cancelSource.Token, TimeSpan.FromSeconds(100));
            System.Threading.Thread.Sleep(1000);
            cancelSource.Cancel();
            result = rTask.Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
