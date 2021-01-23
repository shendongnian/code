    public static string CompressLzma(string inputstring)
    {
    	if (!string.IsNullOrEmpty(inputstring))
    	{
    		var stream = new MemoryStream(Encoding.UTF8.GetBytes(inputstring ?? ""));
    		var outputStream = new MemoryStream();
    		Compress(stream, outputStream);
    
    
    		byte[] bytes = outputStream.ToArray();
    		var result = string.Join(",", Array.ConvertAll(bytes, v => signedInt((int)v)));
    		return result;
    	}
    
    	return "";
    }
    
    
    public static void PrepareEncoder(out CoderPropID[] propIDs, out object[] properties)
    {
    	bool eos = true;
    	Int32 dictionary = 1 << 16;
    	Int32 posStateBits = 2;
    	Int32 litContextBits = 3; // for normal files
    	// UInt32 litContextBits = 0; // for 32-bit data
    	Int32 litPosBits = 0;
    	// UInt32 litPosBits = 2; // for 32-bit data
    	Int32 algorithm = 2;
    	Int32 numFastBytes = 64;
    	string mf = "bt4";
    
    	propIDs = new CoderPropID[]
    	{
    	   CoderPropID.DictionarySize,
    	   CoderPropID.PosStateBits,
    	   CoderPropID.LitContextBits,
    	   CoderPropID.LitPosBits,
    	   CoderPropID.Algorithm,
    	   CoderPropID.NumFastBytes,
    	   CoderPropID.MatchFinder,
    	   CoderPropID.EndMarker
    	};
    	properties = new object[]
    	{
    	   dictionary,
    	   posStateBits,
    	   litContextBits,
    	   litPosBits,
    	   algorithm,
    	   numFastBytes,
    	   mf,
    	   eos
    	};
    }
    
    private static int signedInt(int unsignedInt)
    {
    	return unsignedInt >= 128 ? Math.Abs(128 - unsignedInt) - 128 : unsignedInt;
    }
    
    
    public static void Compress(MemoryStream inStream, MemoryStream outStream)
    {
    	CoderPropID[] propIDs;
    	object[] properties;
    	PrepareEncoder(out propIDs, out properties);
    
    	SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();
    	encoder.SetCoderProperties(propIDs, properties);
    	encoder.WriteCoderProperties(outStream);
    	Int64 fileSize = inStream.Length;
    	for (int i = 0; i < 8; i++)
    	{
    		outStream.WriteByte((Byte)(fileSize >> (8 * i)));
    	}
    	encoder.Code(inStream, outStream, -1, -1, null);
    }
