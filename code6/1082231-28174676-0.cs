    public class MyNetworkStream : IDisposable
    {
        private NetworkStream stream;
        private ConcurrentDictionary<int, TaskCompletionSource<byte[]>> lookup =
            new ConcurrentDictionary<int, TaskCompletionSource<byte[]>>();
        private CancellationTokenSource disposalCTS = new CancellationTokenSource();
        public MyNetworkStream(Socket socket)
        {
            stream = new NetworkStream(socket);
            KeepReading();
        }
        public void Dispose()
        {
            disposalCTS.Cancel();
            stream.Dispose();
        }
        public Task<byte[]> WriteAndWaitAsync(byte[] buffer, int offset, 
            int count, int uniqueID)
        {
            var tcs = lookup.GetOrAdd(uniqueID, new TaskCompletionSource<byte[]>());
            stream.WriteAsync(buffer, offset, count);
            return tcs.Task;
        }
        private async void KeepReading()
        {
            try
            {
                //TODO figure out what you want for a buffer size so that you can 
                //read a block of the appropriate size.
                byte[] buffer = null;
                while (!disposalCTS.IsCancellationRequested)
                {
                    //TODO edit offset and count appropriately 
                    await stream.ReadAsync(buffer, 0, 0, disposalCTS.Token);
                    int id = GetUniqueIdFromBlock(buffer);
                    TaskCompletionSource<byte[]> tcs;
                    if (lookup.TryRemove(id, out tcs))
                        tcs.TrySetResult(buffer);
                    else
                    {
                        //TODO figure out what to do here
                    }
                }
            }
            catch (Exception e)
            {
                foreach (var tcs in lookup.Values)
                    tcs.TrySetException(e);
                Dispose();
                //TODO consider any other necessary cleanup
            }
        }
        private int GetUniqueIdFromBlock(byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
