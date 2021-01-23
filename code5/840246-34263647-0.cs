    public static async Task<byte[]> DownloadDataTaskAsync(this WebClient obj, Uri address, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            var task = obj.DownloadDataTaskAsync(address);
            using (cancellationToken.Register(s => ((TaskCompletionSource<bool>)s).TrySetResult(true), tcs))
            {
                if (task != await Task.WhenAny(task, tcs.Task))
                {
                    throw new OperationCanceledException(cancellationToken);
                }
            }
            return await task;
        }
