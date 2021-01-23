    public static byte[] Compress(byte[] data, CompressionLevel level = CompressionLevel.Fastest)
    {
    	using (var memory = new MemoryStream())
    	{
    		using (var gzip = new GZipStream(memory, level, true))
    		{
    			gzip.Write(data, 0, data.Length);
    		}
    		return memory.ToArray();
    	}
    }
