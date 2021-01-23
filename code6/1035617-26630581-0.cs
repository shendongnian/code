    public static void Extension(this Abstract a)
    {
        Console.WriteLine("Base");
        dynamic d = a;
        Extensions.Extension(d);
    }
