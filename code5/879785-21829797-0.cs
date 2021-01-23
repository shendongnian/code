    using(var dest = File.Open(@"d:\foo.bin", FileMode.OpenOrCreate))
    {
        Append(dest, file);
        Append(dest, anotherFile);
    }
    ...
    static void AppendFile(Stream dest, string path)
    {
        using(var source = File.OpenRead(path))
        {
            var lenHeader = BitConverter.GetBytes(source.Length);
            dest.Write(lenHeader, 0, 4);
            source.CopyTo(dest);
        }
    }
