     static void Main(string[] args)
        {
            var task = GetValueWithTimeout(1000);
            Console.WriteLine(task.Result);
            Console.ReadLine();
        }
        static async Task<int> GetValueWithTimeout(int milliseconds)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            cts.CancelAfter(milliseconds);
            token.ThrowIfCancellationRequested();
            var workerTask = Task.Run(async () =>
            {
                await Task.Delay(3500, token);
                return 10;
            }, token);
            try
            {
                return await workerTask;
            }
            catch (OperationCanceledException )
            {
                return 0;
            }
        }
