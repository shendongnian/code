    // C# Code, CipherMode.CBC
    // CBC version need Initialization vector IV.
    
    public static string keyStr = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
    private static string Encrypt(string PlainText)
    {
    	RijndaelManaged aes = new RijndaelManaged();
    	aes.BlockSize = 128;
    	aes.KeySize = 256;
    
    	// It is equal in java 
    	/// Cipher _Cipher = Cipher.getInstance("AES/CBC/PKCS5PADDING");	
    	aes.Mode = CipherMode.CBC;	
    	aes.Padding = PaddingMode.PKCS7; 
    
    	byte[] keyArr = Convert.FromBase64String(keyStr);
    	byte[] KeyArrBytes32Value = new byte[32];
    	Array.Copy(keyArr, KeyArrBytes32Value, 32);
    
    	// Initialization vector.   
    	// It could be any value or generated using a random number generator.
    	byte[] ivArr = { 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 2, 1, 7, 7, 7, 7 };
    	byte[] IVBytes16Value = new byte[16];
    	Array.Copy(ivArr, IVBytes16Value, 16);
    
    	aes.Key = KeyArrBytes32Value;
    	aes.IV = IVBytes16Value;
    
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
    
    	aes.Mode = CipherMode.CBC;
    	aes.Padding = PaddingMode.PKCS7;
    
    	byte[] keyArr = Convert.FromBase64String(keyStr);
    	byte[] KeyArrBytes32Value = new byte[32];
    	Array.Copy(keyArr, KeyArrBytes32Value, 32);
    
    	// Initialization vector.   
    	// It could be any value or generated using a random number generator.
    	byte[] ivArr = { 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 2, 1, 7, 7, 7, 7 };            
    	byte[] IVBytes16Value = new byte[16];
    	Array.Copy(ivArr, IVBytes16Value, 16);
    
    	aes.Key = KeyArrBytes32Value;
    	aes.IV = IVBytes16Value;
    
    	ICryptoTransform decrypto = aes.CreateDecryptor();
    
    	byte[] encryptedBytes = Convert.FromBase64CharArray(CipherText.ToCharArray(), 0, CipherText.Length);
    	byte[] decryptedData = decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
    	return ASCIIEncoding.UTF8.GetString(decryptedData);
    }
