	public static byte[] SerializeAndCompress(this object obj) 
	{
		using (MemoryStream ms = new MemoryStream()) 
		using (GZipStream zs = new GZipStream(ms, CompressionMode.Compress, true))
		{
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(zs, obj);
			return ms.ToArray();
		}
	}
	
	public static T DecompressAndDeserialize<T>(this byte[] data)
	{
		using (MemoryStream ms = new MemoryStream(data)) 
		using (GZipStream zs = new GZipStream(ms, CompressionMode.Decompress, true))
		{
			BinaryFormatter bf = new BinaryFormatter();
			return (T)bf.Deserialize(zs);
		}
	}
