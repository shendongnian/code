    public static void myCallback(IAsyncResult iar)
    {
      AsyncResult ar = (AsyncResult)iar;
      ReadFile readf = (ReadFile)ar.AsyncDelegate;
      string line = readf.EndInvoke(iar);
      lock(obj)
      {
        writefile.writeLine(line);
        successCount++;
      }
     }
    private static object obj = new object();
    private static int successCount = 0;
    static void Main(string[] args)
     {
        readFileAsync(filereader1);
        readFileAsync(filereader2);
        readFileAsync(filereader3);
        while(Console.ReadKey())
        {
            if(successCount == 3)
            {
                filereader1.Dispose();
                filereader2.Dispose();
                filereader3.Dispose();
                writefile.Dispose();
                break;
            }
        }
    }
