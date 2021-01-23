    private static void ReadFew(IEnumerable<byte> list)
    {
        var iter = list.GetEnumerator();
        while (iter.MoveNext() && iter.Current != 3)
        {
        }
    }
    using (MemoryStream memStream = new MemoryStream(new byte[] { 0, 1, 2, 3, 4, 5 }))
    using (MyBinaryReader reader = new MyBinaryReader(memStream))
    {
        ReadFew(reader);
        Console.WriteLine("Reader stopped at position: " + memStream.Position);
    }
