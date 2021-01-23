     static void Main(string[] args)
     {
         runSingleFile("ConsoleApplication2.exe", "");
         runSingleFile("ConsoleApplication2.exe", "");
         runSingleFile("ConsoleApplication2.exe", "");
         while (processCount > 0)
         {
            System.Threading.Thread.Sleep(100);
         }
     }
