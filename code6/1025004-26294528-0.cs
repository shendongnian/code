    struct Ex
    {
      public byte f0;
      public byte f1;
      public byte f2;
      public byte f3;
      public byte f4;
    }
    
    class Program
    {
      public static unsafe Ex ByteArrayToEx(Ex* obj, int StartOffset, params byte[] bytes)
      { // you should add some safely nets here sizeof(Ex) should used for size of struct
        byte* p = (byte*)obj;
        foreach (var b in bytes)
        {
          p[StartOffset++] = b;
        }
        return *obj;
      }
    
      unsafe static void Main(string[] args)
      {
        Stopwatch sw = new Stopwatch();
        Ex e = new Ex { f0 = 0, f1 = 1, f2 = 2, f3 = 3, f4 = 4 };
        Ex ne = ByteArrayToEx(&e, 2, 5, 6, 7); // return is a copy
        for (int i = 0; i < 10; i++) {
          sw.Restart();
          ne = ByteArrayToEx(&e, 2, (byte) i, 6, 7);
          sw.Stop();
          Console.WriteLine(sw.ElapsedTicks);
        }
      }
    }
