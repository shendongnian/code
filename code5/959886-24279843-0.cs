    public static void Main(string[] args)
    {
        using (var t = new DisposableClassWithStream())
        {
        t.WriteLine("Test");
        }
    }
