    Total memory: 94.804 bytes
    Private bytes 19230720
    Handle count: 252
    --- New object #1 ---
    Total memory: 96.932 bytes
    Private bytes 19820544
    Handle count: 252
    --- New object #2 ---
    Total memory: 96.932 bytes
    Private bytes 19820544
    Handle count: 252
    --- New object #3 ---
    Total memory: 96.932 bytes
    Private bytes 19820544
    Handle count: 252
    --- New object #4 ---
    Total memory: 96.932 bytes
    Private bytes 19820544
    Handle count: 252
    --- New object #5 ---
    Total memory: 96.932 bytes
    Private bytes 19820544
    Handle count: 252
    --- press any key to quit ---
    Total memory: 96.920 bytes
    Private bytes 19820544
    Handle count: 252
----------
    class Program
    {
    static void DisplayMemory()
    {
        Console.WriteLine("Total memory: {0:###,###,###,##0} bytes", GC.GetTotalMemory(true));
        Console.WriteLine("Private bytes {0}", System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64);
      Console.WriteLine("Handle count: {0}", System.Diagnostics.Process.GetCurrentProcess().HandleCount);
        Console.WriteLine();
     }
     static void Main()
     {
      DisplayMemory();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
       for (int i = 0; i < 5; i++)
       {
         Console.WriteLine("--- New object #{0} ---", i + 1);
         object o = new object();
         GC.Collect();
         GC.WaitForPendingFinalizers();
         GC.Collect();
         DisplayMemory();
       }
       Console.WriteLine("--- press any key to quit ---");
      //Console.ReadLine();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForFullGCComplete();
      DisplayMemory();
      Console.ReadLine();
    }
