    public class MyClass
    {
        private int filesRead = 0;
        public void Go()
        {
            GoAsync().Wait();
        }
        private async Task GoAsync()
        {
            string[] fileSystemEntries = Directory.GetFileSystemEntries(@"Path\To\Files");
            Console.WriteLine("Starting to read from files! Count: {0}", fileSystemEntries.Length);
            var tasks = fileSystemEntries.OrderBy(s => s).Select(
                fileName => DoStuffAsync(fileName));
            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine("Finish! Read {0} file(s).", filesRead);
        }
        private async Task DoStuffAsync(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            using (var reader = new StreamReader(fileName))
            {
                string firstLineOfFile = 
                    await reader.ReadLineAsync().ConfigureAwait(false);
                Console.WriteLine("[{0}] {1}: {2}", Thread.CurrentThread.ManagedThreadId, fileName, firstLineOfFile);
                Interlocked.Increment(ref filesRead);
            }
        }
    }
