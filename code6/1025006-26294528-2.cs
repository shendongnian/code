    unsafe struct Ex
    {
      public byte f0,f1,f2,f3,f4;
      public fixed int buffer[20000];
    }
    
    class Program
    {
      public static unsafe void ByteArrayToEx(Ex* obj, int offset, params byte[] bytes)
      { 
        // you should add some safely nets here sizeof(Ex) should used for size of struct
        byte* p = (byte*)obj;
        foreach (var b in bytes)
        {
          p[offset++] = b;
        }
        // dont return value, it is expensive!
      }
    
      unsafe static void Main(string[] args)
      {
        Stopwatch sw = new Stopwatch();
        Ex e = new Ex { f0 = 0, f1 = 1, f2 = 2, f3 = 3, f4 = 4 };
        ByteArrayToEx(&e, 2, 5, 6, 7);
        for (int i = 0; i < 10; i++) {
          sw.Restart();
          ByteArrayToEx(&e, 2, (byte) i, 6, 7);
          sw.Stop();
          Console.WriteLine(sw.ElapsedTicks);
        }
      }
    }
