    class Program
    {
        private static MemoryMappedFile _file = MemoryMappedFile.CreateOrOpen("XXX_YYY", 1, MemoryMappedFileAccess.ReadWrite);
        private static MemoryMappedViewAccessor _view = _file.CreateViewAccessor();
        static void Main(string[] args)
        {
            askforinput:
            Console.WriteLine("R for read, W for write");
            string input = Console.ReadLine();
            if (string.Equals(input, "r", StringComparison.InvariantCultureIgnoreCase))
                StartReading();
            else if (string.Equals(input, "w", StringComparison.InvariantCultureIgnoreCase))
                StartWriting();
            else
                goto askforinput;
            
            _view.Dispose();
            _file.Dispose();   
        }
              
        private static void StartReading()
        {
            
            bool currVal = false;
            for (int i = 0; i < 100; i++)
            {
                currVal = currVal != true;
                Console.WriteLine(_view.ReadBoolean(0));
                Thread.Sleep(221);
            }
        }
        private static void StartWriting()
        {
            
            bool currVal = false;
            for (int i = 0; i < 100; i++)
            {
                currVal = currVal != true;
                _view.Write(0, currVal);
                Console.WriteLine("Writen: " + currVal.ToString());
                Thread.Sleep(500);
            }
        }
    }
