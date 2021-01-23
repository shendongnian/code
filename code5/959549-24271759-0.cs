    public byte[] Encrypt(string m, Encoding encoding)
    {
    	byte[] bytes = encoding.GetBytes(m);
    	byte[] returnBytes = new byte[0];
    	for (int i = 0; i < bytes.Length; i++)
    	{
    		byte[] result = BigInteger.ModPow(bytes[i], (BigInteger)e, n).ToByteArray();
    		int preSize = returnBytes.Length;
    		Array.Resize(ref returnBytes, returnBytes.Length + result.Length + 1);
    		(new byte[] { (byte)(result.Length) }).CopyTo(returnBytes, preSize);
    		result.CopyTo(returnBytes, preSize + 1);
    	}
    	return returnBytes;
    }
    
    public string Decrypt(byte[] c, Encoding encoding)
    {
    	byte[] returnBytes = new byte[0];
    	for (int i = 0; i < c.Length; i++)
    	{
    		int dataLength = (int)c[i];
    		byte[] result = new byte[dataLength];
    		for (int j = 0; j < dataLength; j++)
    		{
    			i++;
    			result[j] = c[i];
    		}
    		BigInteger integer = new BigInteger(result);
    		byte[] integerResult = BigInteger.ModPow(integer, d, n).ToByteArray();
    		int preSize = returnBytes.Length;
    		Array.Resize(ref returnBytes, returnBytes.Length + integerResult.Length);
    		integerResult.CopyTo(returnBytes, preSize);
    	}
    	string decryptedString = encoding.GetString(returnBytes);
    	return decryptedString;
    }
