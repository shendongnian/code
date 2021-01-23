    using (var writer = new BinaryWriter(File.Create("foo.bin")))
    {
        writer.Write(1.250F);
        writer.Write(@"c:\Temp");
        writer.Write(10);
        writer.Write(true);
    }
    var bytes = File.ReadAllBytes("foo.bin");
    var text = BitConverter.ToString(bytes);
    Console.WriteLine(text);
