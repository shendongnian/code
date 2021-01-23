        static void Main(string[] args)
        {
            string cacheFileName = @"C:\temp.txt";
            using (var filestream = new FileStream(cacheFileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete, 4096, FileOptions.SequentialScan))
            {
                filestream.Read(new byte[100], 1, 1);
                Console.ReadLine();
                GC.KeepAlive(filestream);
            }
            Console.WriteLine("Done!");
        }
    }
