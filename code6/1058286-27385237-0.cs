    static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
    {
    	ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
    
    	using (MemoryStream msDecrypt = new MemoryStream(cipherText))
    	{
    		using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
    		{
    			using (StreamReader srDecrypt = new StreamReader(csDecrypt))
    			{
    				return srDecrypt.ReadToEnd();
    			}
    		}
    	}
    }
