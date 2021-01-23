     static void Main(string[] args)
     {
         runSingleFile("ConsoleApplication2.exe", "");
         runSingleFile("ConsoleApplication2.exe", "");
         runSingleFile("ConsoleApplication2.exe", "");
         while (Interlocked.Read(ref processCount) > 0)
         {
            System.Threading.Thread.Sleep(100);
         }
     }
