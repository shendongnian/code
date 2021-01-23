    public static byte[] StringToByteArray(string hex)
    {
    	int numberChars = hex.Length;
    	var bytes = new byte[numberChars / 2];
    	for (int i = 0; i < numberChars; i += 2)
    		bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
    	return bytes;
    }
