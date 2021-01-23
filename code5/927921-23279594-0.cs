    internal class Program
    {
        private static void Main()
        {
            var readOperation = new ManualResetEventSlim();
            var stream = new MemoryStream();
            Task.Factory.StartNew(() =>
            {
                using (var writer = XmlWriter.Create(stream))
                {
                    Console.WriteLine(
                        "Thread {0} is writing...", 
                        Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(3000);
                    CreateXmlDocument(writer);
                }
                stream.Position = 0;
                readOperation.Set();
            });
            Task.Factory.StartNew(() =>
            {
                readOperation.Wait();
                using (var reader = XmlReader.Create(stream))
                    while (reader.Read())
                        Console.WriteLine(
                            "Thread {0} is reading...", 
                            Thread.CurrentThread.ManagedThreadId);
            });
            Console.ReadKey();
        }
    }
