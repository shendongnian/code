    new VirtualFileDataObject.FileDescriptor
    {
        Name = "Alphabet.txt",
        Length = 26,
        ChangeTimeUtc = DateTime.Now.AddDays(-1),
        StreamContents = () =>
        {
            var contents = Enumerable.Range('a', 26).Select(i => (byte)i).ToArray();
            MemoryStream ms = new MemoryStream(contents); // don't dispose/using here, it would be too early
            return ms;
        }
    };
