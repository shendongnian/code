    public static void Serialize(Stereo[] stereos, Stream destination)
    {
        using (GZipStream compressionStream = new GZipStream(destination, CompressionMode.Compress, true))
        using (BinaryWriter writer = new BinaryWriter(compressionStream, Encoding.Default, true))
        {
            //No changes here required
        }
    }
    public static Stereo[] Deseralize(Stream source)
    {
        using (GZipStream decompressionStream = new GZipStream(source, CompressionMode.Decompress, true))
        using (BinaryReader reader = new BinaryReader(source, Encoding.Default, true))
        {
            //No changes here required
        }
    }
