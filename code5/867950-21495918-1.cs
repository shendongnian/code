    using (var fs = File.Create(...))
    using (var bw = new BinaryWriter(fs))
    {
        foreach (var file in Directory.GetFiles(...))
        {
            bw.Write(true); // means that a file will follow
            bw.Write(Path.GetFileName(file));
            var data = File.ReadAllBytes(file);
            bw.Write(data.Length);
            bw.Write(data);
        }
        bw.Write(false); // means end of file
    }
