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
                int position = 0; //Hold the position of reading from the stream
                while (true)
                {
                    lock (stream)
                    {
                        byte[] buffer = new byte[1024];
                        stream.Position = position;
                        position += stream.Read(buffer, 0, buffer.Length); //Add the read bytes to the position
                        
                        string s = Encoding.UTF8.GetString(buffer);
                    }
                }
                Thread.Sleep(150);
            });
        }
        static void StreamWriterThread()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                int i = 33; //Only for example
                int position = 0; //Holds the position of writing into the stream
                while (true)
                {
                    lock (stream)
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(new String((char)(i++),1024));
                        stream.Position = position;
                        stream.Write(buffer, 0, buffer.Length);
                        position += buffer.Length;
                    }
                    i%=125;//Only for example
                    if (i == 0) i = 33;//Only for example
                    Thread.Sleep(100);
                }
            });
        }
    }
