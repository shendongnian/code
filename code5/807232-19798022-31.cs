    var tasks = new Task[Environment.ProcessorCount];
    int bufferSize = 65536; // 64Kb
    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read,
            FileShare.Read, bufferSize, FileOptions.RandomAccess))
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Factory.StartNew(() =>
                {
                    int readBuffer = 0;
                    var lineBuffer = new byte[bufferSize];
                    while ((readBuffer = fs.Read(lineBuffer, 0, lineBuffer.Length)) > 0)
                    {
                        for (int n = 0; n < readBuffer; n++)
                            if (lineBuffer[n] == 0xD)
                                Interlocked.Increment(ref lineCount);
                    }
                });
        }
        Task.WaitAll(tasks);
    }
