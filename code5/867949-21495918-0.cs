    using (var fs = File.Create(...))
    using (var bw = new BinaryWriter(fs))
    {
        foreach (var file in Directory.GetFiles(...))
        {
            bw.Write(true); // means that a file will follow
            bw.Write(Path.GetFileName(file));
            bw.Write(File.ReadAllBytes(file));
        }
        bw.Write(false); // means end of file
    }
