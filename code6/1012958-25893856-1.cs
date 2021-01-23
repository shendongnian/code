    public static void EncryptFile(string path, string key, string saltkey, string ivkey)
    {
    	byte[] TextBytes = File.ReadAllBytes(path);
    	
    	byte[] KeyBytes = new Rfc2898DeriveBytes(key, Encoding.ASCII.GetBytes(saltkey)).GetBytes(256 / 8);
    	
    	RijndaelManaged symmetricKey = new RijndaelManaged() { Mode = CipherMode.CFB, Padding = PaddingMode.PKCS7 };
    	ICryptoTransform encryptor = symmetricKey.CreateEncryptor(KeyBytes, Encoding.ASCII.GetBytes(ivkey));
    	
    	byte[] CipherTextBytes;
    	
    	using (MemoryStream ms = new MemoryStream())
    	using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
    	{
    		cs.Write(TextBytes, 0, TextBytes.Length);
    		cs.FlushFinalBlock();         
    		
    		CipherTextBytes = ms.ToArray();
    	}
    	
    	File.WriteAllBytes(path, CipherTextBytes);
    }
