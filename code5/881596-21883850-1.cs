    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var sourcePath = @"D:\dummy.bin";
            var destinationPath = @"D:\dummy.bin.copy";
            var sourceFile = new FileInfo(sourcePath);
            var fileSize = sourceFile.Length;
            var currentBytesTransferred = 0L;
            var totalBytesTransferred = 0L;
            var snapshots = new Queue<long>(30);
            var timer = new System.Timers.Timer(1000D);
            timer.Elapsed += (sender, e) =>
            {
                // Remember only the last 30 snapshots; discard older snapshots
                if (snapshots.Count == 30)
                {
                    snapshots.Dequeue();
                }
    
                snapshots.Enqueue(Interlocked.Exchange(ref currentBytesTransferred, 0L));
                var averageSpeed = snapshots.Average();
                var bytesLeft = fileSize - totalBytesTransferred;
                Console.WriteLine("Average speed: {0:#} MBytes / second", averageSpeed / (1024 * 1024));
                if (averageSpeed > 0)
                {
                    var timeLeft = TimeSpan.FromSeconds(bytesLeft / averageSpeed);
                    var timeLeftRounded = TimeSpan.FromSeconds(Math.Round(timeLeft.TotalSeconds));
                    Console.WriteLine("Time left: {0}", timeLeftRounded);
                }
                else
                {
                    Console.WriteLine("Time left: Infinite");
                }
            };
    
            using (var inputStream = sourceFile.OpenRead())
            using (var outputStream = File.OpenWrite(destinationPath))
            {
                timer.Start();
                var buffer = new byte[4096];
                var numBytes = default(int);
                var numBytesMax = buffer.Length;
                var timeout = TimeSpan.FromMinutes(10D);
                do
                {
                    var mre = new ManualResetEvent(false);
                    inputStream.BeginRead(buffer, 0, numBytesMax, asyncReadResult =>
                    {
                        numBytes = inputStream.EndRead(asyncReadResult);
                        outputStream.BeginWrite(buffer, 0, numBytes, asyncWriteResult =>
                        {
                            outputStream.EndWrite(asyncWriteResult);
                            currentBytesTransferred = Interlocked.Add(ref currentBytesTransferred, numBytes);
                            totalBytesTransferred = Interlocked.Add(ref totalBytesTransferred, numBytes);
                            mre.Set();
                        }, null);
                    }, null);
                    mre.WaitOne(timeout);
                } while (numBytes != 0);
                timer.Stop();
            }
        }
    }
