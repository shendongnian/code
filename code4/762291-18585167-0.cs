     class Program
        {
            const string Filepath = "D:\\Vivek.txt";
            static AutoResetEvent writerwaithandle = new AutoResetEvent(true);// Signaled state
            static AutoResetEvent readerwaithandle = new AutoResetEvent(false);
    
            static void Main()
            {
    
                if (File.Exists(Filepath))
                {
                    File.Delete(Filepath);
                }
    
                //File.CreateText(Filepath);
                CreateWriterThread();
                CreateReaderThread();
                Console.ReadKey();
            }
    
            private static void CreateWriterThread()
            {
                for (int i = 1; i <= 10; i++)
                {
    
                    var thread = new Thread(WriteFile);
                    thread.Name = "Writer " + i;
                    thread.Start();
                    Thread.Sleep(250);
                }
    
            }
    
            private static void CreateReaderThread()
            {
                for (int i = 1; i <= 10; i++)
                {
                    var thread = new Thread(ReadFile);
                    thread.Name = "Reader " + i;
                    thread.Start();
                }
            }
    
            private static void WriteFile()
            {
                writerwaithandle.WaitOne();
    
    
                var streamwriter = File.CreateText(Filepath);
    
                //var stream = new FileStream(Filepath, FileMode.Append);
                //var streamwriter = new StreamWriter(stream);
                streamwriter.WriteLine("written by" + Thread.CurrentThread.Name + DateTime.Now);
                streamwriter.Flush();
                streamwriter.Close();
    
                readerwaithandle.Set();
            }
    
            private static void ReadFile()
            {
                readerwaithandle.WaitOne();
                if (File.Exists(Filepath))
                {
                    var stream = new FileStream(Filepath, FileMode.Open);
                    var streamreader = new StreamReader(stream);
                    var text = streamreader.ReadToEnd();
                    streamreader.Close();
                    Console.WriteLine("Read by thread {0} \n", Thread.CurrentThread.Name);
                    Console.WriteLine(text);
                }
                writerwaithandle.Set();
            }
        }
