    var bytes = new List<byte[]>(new[]
    	{
    		LittleEndianBitConverter.GetBytes(message.LongLength), 
    		LittleEndianBitConverter.GetBytes(0l), 
    		message
    	});
    var msg = new byte[bytes.Sum(barray => barray.LongLength)];
    int offset = 0;
    foreach (var bArray in bytes)
    {
    	System.Buffer.BlockCopy(bArray, 0, msg, offset, bArray.Length);
    	offset = bArray.Length;
    }
