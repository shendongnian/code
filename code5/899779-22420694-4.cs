    Test writer;
    using (var fs = new FileStream("sample.txt", FileMode.Open))
    {
         writer = new Test(fs);
         writer = writer.Write(232323);
         writer = writer.Write(true);
         writer = writer.Write(12);
    }
    using (var fs = File.Open("sample.txt", FileMode.Open))
    {
        var reader = new BinaryReader(fs);
        Console.WriteLine(reader.ReadInt32());  // 232323
        Console.WriteLine(reader.ReadBoolean()); // true
        Console.WriteLine(reader.ReadByte());    // 12
    }
