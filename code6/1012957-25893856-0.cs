    public static void DecryptFile(string path, string key, string saltkey, string ivkey)
    {
    	byte[] cipherTextBytes = File.ReadAllBytes(path);
    	
    	byte[] keyBytes = new Rfc2898DeriveBytes(key, Encoding.ASCII.GetBytes(saltkey)).GetBytes(256 / 8);
    	
    	RijndaelManaged symmetricKey = new RijndaelManaged() { Mode = CipherMode.CFB, Padding = PaddingMode.PKCS7 };
    	ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(ivkey));
    	
    	byte[] plainTextBytes;
    	
    	const int chunkSize = 64;
    	
    	using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
    	using (MemoryStream dataOut = new MemoryStream())
    	using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
    	using (var decryptedData = new BinaryReader(cryptoStream))
    	{
    		byte[] buffer = new byte[chunkSize];
    		int count;
    		while ((count = decryptedData.Read(buffer, 0, buffer.Length)) != 0)
    		dataOut.Write(buffer, 0, count);
    		
    		plainTextBytes = dataOut.ToArray();
    	}	  
    	
    	File.WriteAllBytes(path, plainTextBytes);
    }
    
