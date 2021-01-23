    public static string DecryptDataAES(byte[] cipherText, byte[] key, byte[] iv)
    		{
    			string plaintext = null;
    
    			using (Rijndael rijAlg = Rijndael.Create())
    			{
    				rijAlg.Key = key;
    				rijAlg.IV = iv;
    
    				ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
    
    				// Create the streams used for decryption. 
    				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
    				{
    					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
    					{
    						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
    						{
    							plaintext = srDecrypt.ReadToEnd();
    						}
    					}
    				}
    
    			}
    
    			return plaintext;
    		}
