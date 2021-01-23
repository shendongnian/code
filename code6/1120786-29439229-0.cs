    public class MyPipeReader
    {
        private string _pipeName;
        public MyPipeReader(string pipeName)
        {
            _pipeName = pipeName;
        }
        public async Task ReceiveAndProcessStuffUntilCancelled(CancellationToken token)
        {
            var received = new byte[4096];
            while (!token.IsCancellationRequested)
            {
                using (var stream = CreateStream())
                {
                    try
                    {
                        if (await WaitForConnection(stream, token))
                        {
                            var bytesRead = 0;
                            do {
                                bytesRead = await stream.ReadAsync(received, 0, 4096, token).ConfigureAwait(false);
                            } while (bytesRead > 0 && DoMessageProcessing(received, bytesRead));
                            if (stream.IsConnected)
                                stream.Disconnect();
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        break; // operation was canceled.
                    }
                    catch (Exception e)
                    {
                        // report error & decide if you want to give up or retry.
                    }
                }
            }
        }
        private NamedPipeServerStream CreateStream()
        {
            return new NamedPipeServerStream(_pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        }
        private async Task<bool> WaitForConnection(NamedPipeServerStream stream, CancellationToken token)
        {
            // We can't simply use 'Task.Factory.FromAsync', as that is not cancelable.
            var tcs = new TaskCompletionSource<bool>();
            var cancelRegistration = token.Register(() => tcs.SetCanceled());
            var iar = stream.BeginWaitForConnection(null, null);
            var rwh = ThreadPool.RegisterWaitForSingleObject(iar.AsyncWaitHandle, delegate { tcs.TrySetResult(true); }, null, -1, true);
            try
            {
                await tcs.Task.ConfigureAwait(false);
                if (iar.IsCompleted) {
                    stream.EndWaitForConnection(iar);
                    return true;
                }
            }
            finally
            {
                cancelRegistration.Dispose();
                rwh.Unregister(null);
            }
            return false;
        }
        private bool DoMessageProcessing(byte[] buffer, int nBytes)
        {
            try
            {
                // Your processing code.
                // You could also make this async in case it does any I/O.
                return true;
            }
            catch (Exception e)
            {
                // report error, and decide what to do.
                // return false if the task should not
                // continue.
                return false;
            }
        }
    }
    class Program
    {
        public static void Main(params string[] args)
        {
            using (var cancelSource = new CancellationTokenSource())
            {
                var receive = new MyPipeReader("_your_pipe_name_here_").ReceiveAndProcessStuffUntilCancelled(cancelSource.Token);
                Console.WriteLine("Press <ENTER> to stop");
                Console.ReadLine();
                cancelSource.Cancel();
                receive.Wait();
            }
        }
    }
