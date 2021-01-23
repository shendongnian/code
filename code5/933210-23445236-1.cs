    public class MyClass
    {
        private int filesRead = 0;
        public void Go()
        {
            string[] fileSystemEntries = Directory.GetFileSystemEntries(@"Path\To\Files");
            Console.WriteLine("Starting to read from files! Count: {0}", fileSystemEntries.Length);
            List<Task> tasks = new List<Task>();
            foreach (var filePath in fileSystemEntries.OrderBy(s => s))
            {
                Task task = Task.Run(() => DoStuff(filePath));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Finish! Read {0} file(s).", filesRead);
        }
        private void DoStuff(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string firstLineOfFile = File.ReadLines(filePath).First();
            Console.WriteLine("[{0}] {1}: {2}", Thread.CurrentThread.ManagedThreadId, fileName, firstLineOfFile);
            filesRead++;
        }
    }
