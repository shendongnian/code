    static void Main(string[] args)
    {
        String s1 = "hello";
        String s2 = "hello";
        String s3 = s2.Clone() as String;
        Console.Out.WriteLine(Get(s1));
        Console.Out.WriteLine(Get(s2));
        Console.Out.WriteLine(Get(s3));
        s1 = Console.In.ReadLine();
        s1 = Console.In.ReadLine();
        s3 = s2.Clone() as String;
        Console.Out.WriteLine(Get(s1));
        Console.Out.WriteLine(Get(s2));
        Console.Out.WriteLine(Get(s3));
    }
    public static string Get(object a)
    {
        GCHandle handle = GCHandle.Alloc(a, GCHandleType.Pinned);
        IntPtr pointer = GCHandle.ToIntPtr(handle);
        handle.Free();
        return "0x" + pointer.ToString("X");
    }
