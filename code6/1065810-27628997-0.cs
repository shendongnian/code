    class Program
    {
       static FileStream stream;
        static void Main(string[] args)
        {
            stream = File.Open(@"C:\test", FileMode.OpenOrCreate);
            StreamWriterThread();
            StreamReaderThread();
            Console.ReadKey();
        }
        static void StreamReaderThread()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                while (true)
                {
                    lock (stream)
                    {
                        byte[] buffer = new byte[1024];
                        stream.Read(buffer, 0, buffer.Length);
                    }
                }
                Thread.Sleep(150);
            });
        }
        static void StreamWriterThread()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                while (true)
                {
                    lock (stream)
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(new String('A',1024));
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    Thread.Sleep(100);
                }
            });
        }
    }
