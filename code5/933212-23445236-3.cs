    public class MyClass
    {
        private int filesRead;
        public void Go()
        {
            string[] fileSystemEntries = Directory.GetFileSystemEntries(@"Path\To\Files");
            Console.WriteLine("Starting to read from files! Count: {0}", fileSystemEntries.Length);
            Parallel.ForEach(fileSystemEntries, DoStuff);
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
