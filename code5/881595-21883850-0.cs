    static void Main(string[] args)
    {
        string sourcePath            = @"D:\dummy.bin";
        string destinationPath       = @"D:\dummy.bin.copy";
        FileInfo sourceFile          = new FileInfo(sourcePath);
        long fileSize                = sourceFile.Length;
        long currentBytesTransferred = 0L;
        long totalBytesTransferred   = 0L;
        Queue<long> snapshots        = new Queue<long>(30);
        System.Timers.Timer timer = new System.Timers.Timer(1000D);
        timer.Elapsed += (object sender, ElapsedEventArgs e) =>
        {
            snapshots.Enqueue(Interlocked.Exchange(ref currentBytesTransferred, 0L));
            double averageSpeed = snapshots.Average();
            long bytesLeft = fileSize - totalBytesTransferred;
            Console.WriteLine("Average speed: {0:#} MBytes / second", averageSpeed / (1024 * 1024));
            TimeSpan timeLeft = default(TimeSpan);
            if ( averageSpeed > 0 )
            {
                timeLeft = TimeSpan.FromSeconds(bytesLeft / averageSpeed);
            }
            else
            {
                timeLeft = Timeout.InfiniteTimeSpan;
            }
            Console.WriteLine("Time left: {0}", TimeSpan.FromSeconds(Math.Round(timeLeft.TotalSeconds)));
        };
        using ( var inputStream = sourceFile.OpenRead() )
        {
            using ( var outputStream = File.OpenWrite(destinationPath) )
            {
                timer.Start();
                byte[] buffer   = new byte[4096];
                int numBytes    = default(int);
                int numBytesMax = buffer.Length;
                TimeSpan timeout = TimeSpan.FromMinutes(10D);
                do
                {
                    ManualResetEvent mre = new ManualResetEvent(false);
                    inputStream.BeginRead(buffer, 0, numBytesMax, new AsyncCallback(asyncReadResult =>
                    {
                        numBytes = inputStream.EndRead(asyncReadResult);
                        outputStream.BeginWrite(buffer, 0, numBytes, new AsyncCallback(asyncWriteResult =>
                        {
                            outputStream.EndWrite(asyncWriteResult);
                            currentBytesTransferred = Interlocked.Add(ref currentBytesTransferred, numBytes);
                            totalBytesTransferred = Interlocked.Add(ref totalBytesTransferred, numBytes);
                            mre.Set();
                        }), null);
                    }), null);
                    mre.WaitOne(timeout);
                } while ( numBytes != 0 );
                timer.Stop();
            }
        }
    }
