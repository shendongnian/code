    class MyNetworkThingy 
    {
        public async Task ReceiveAndProcessStuffUntilCancelled(Stream stream, CancellationToken token)
        {
            var received = new byte[4096];
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var bytesRead = await stream.ReadAsync(received, 0, 4096, token);
                    if (bytesRead == 0 || !DoMessageProcessing(received, bytesRead))
                        break; // done.
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
            using (var myStream = /* create the stream */)
            {
                var receive = new MyNetworkThingy().ReceiveAndProcessStuffUntilCancelled(myStream, cancelSource.Token);
                Console.WriteLine("Press <ENTER> to stop");
                Console.ReadLine();
                cancelSource.Cancel();
                receive.Wait();
            }
        }
    }
.
