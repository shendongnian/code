    static IEnumerable<string> ReadLines(byte[] source, Encoding enc = null)
    {
        using(var ms = new MemoryStream(source))
        using(var reader = new StreamReader(ms, enc ?? Encoding.UTF8))
        {
            string line;
            while((line = reader.ReadLine()) != null)
                yield return line;
        }
    }
