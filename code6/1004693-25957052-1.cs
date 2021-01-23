    var bytes = File.ReadAllBytes(@"input file path");
    using (MemoryStream ms = new MemoryStream(bytes))
    {
        var result = SharpZip.CreateToMemoryStream(ms, "file.jpg");
        using (var outputStream = File.Create(@"output file path"))
        {
            result.WriteTo(outputStream);
        }
    }
