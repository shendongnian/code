    class Program
    {
        static void Main(string[] args)
        {
            //var cts = new CancellationTokenSource(6000); // To let the operation complete
            var cts = new CancellationTokenSource(1000);
            var ct = cts.Token;
            Task<string> task = ShouldHaveBeenAsynchronous(cts.Token);
            try
            {
                Console.WriteLine(task.Result);
            }
            catch (AggregateException aex)
            {
                foreach (var ex in aex.Flatten().InnerExceptions)
                {
                    var oce = ex as OperationCanceledException;
                    if (oce != null)
                    {
                        if (oce.CancellationToken == ct)
                            Console.WriteLine("OK: Normal Cancellation");
                        else
                            Console.WriteLine("ERROR: Unexpected cancellation");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                    }
                }
            }
            Console.Write("Press Enter to Exit:");
            Console.ReadLine();
        }
        static Task<string> ShouldHaveBeenAsynchronous(CancellationToken ct)
        {
            var tcs = new TaskCompletionSource<string>();
            try
            {
                //throw new NotImplementedException();
                ct.WaitHandle.WaitOne(5000);
                ct.ThrowIfCancellationRequested();
                tcs.TrySetResult("this is the result");
            }
            catch (OperationCanceledException ex)
            {
                if (ex.CancellationToken == ct)
                    tcs.TrySetCanceled(ct);
                else
                    tcs.TrySetException(ex);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
            return tcs.Task;
            //return tcs.TaskWithCancellation(ct, false);
        }
    }
