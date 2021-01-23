    using (MemoryStream ms = new MemoryStream())
    using (FileStream file = File.OpenRead(@"input file path"))
    {
        byte[] bytes = new byte[file.Length];
        file.Read(bytes, 0, (int)file.Length);
        ms.Write(bytes, 0, (int)file.Length);
        ms.Position = 0; // "Rewind" the stream to the beginning.
        var result = SharpZip.CreateToMemoryStream(ms, "file.jpg");
        using (var outputStream = File.Create(@"output file path"))
        {
            result.WriteTo(outputStream);
        }
    }
