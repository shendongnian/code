    /// C# Error Fixed Version - CipherMode.ECB
    public static string keyStr = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
    
    private static string Encrypt(string PlainText)
    {
    	RijndaelManaged aes = new RijndaelManaged();
    	aes.BlockSize = 128;
    	aes.KeySize = 256;
    
    	/// In Java, Same with below code
    	/// Cipher _Cipher = Cipher.getInstance("AES");  // Java Code
    	aes.Mode = CipherMode.ECB; 
    
    	byte[] keyArr = Convert.FromBase64String(keyStr);
    	byte[] KeyArrBytes32Value = new byte[32];
    	Array.Copy(keyArr, KeyArrBytes32Value, 32);
    
    	aes.Key = KeyArrBytes32Value;
    
    	ICryptoTransform encrypto = aes.CreateEncryptor();
    
    	byte[] plainTextByte = ASCIIEncoding.UTF8.GetBytes(PlainText);
    	byte[] CipherText = encrypto.TransformFinalBlock(plainTextByte, 0, plainTextByte.Length);
    	return Convert.ToBase64String(CipherText);
    }
    
    private static string Decrypt(string CipherText)
    {  
    	RijndaelManaged aes = new RijndaelManaged();
    	aes.BlockSize = 128;
    	aes.KeySize = 256;
    
    	/// In Java, Same with below code
    	/// Cipher _Cipher = Cipher.getInstance("AES");  // Java Code
    	aes.Mode = CipherMode.ECB;
       
    	byte[] keyArr = Convert.FromBase64String(keyStr);
    	byte[] KeyArrBytes32Value = new byte[32];
    	Array.Copy(keyArr, KeyArrBytes32Value, 32);
    
    	aes.Key = KeyArrBytes32Value;
    
    	ICryptoTransform decrypto = aes.CreateDecryptor();
    
    	byte[] encryptedBytes = Convert.FromBase64CharArray(CipherText.ToCharArray(), 0, CipherText.Length);
    	byte[] decryptedData = decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
    	return ASCIIEncoding.UTF8.GetString(decryptedData);
    }
