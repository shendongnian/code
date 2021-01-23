    public static string Decrypt2(string cipher,string key)
    {
    	try
    	{
    		byte[] clearBytes = Convert.FromBase64String(cipher);
    		MD5 md5 = new MD5CryptoServiceProvider();
    		byte[] md5Bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
    		string encryptedText = "";
    		TripleDES des = new TripleDESCryptoServiceProvider();
    		des.KeySize = 128;
    		des.Mode = CipherMode.CBC;
    		des.Padding = PaddingMode.PKCS7;
    		byte[] ivBytes = new byte[8];
    		des.Key = md5Bytes;
    		des.IV = ivBytes;
    		ICryptoTransform ct = des.CreateDecryptor();
    		byte[] resultArray = ct.TransformFinalBlock(clearBytes, 0, clearBytes.Length);
    		encryptedText = Encoding.Unicode.GetString(resultArray);
    		return encryptedText;
    	}
    	catch (Exception exception)
    	{
    		return "";
    	}
    }
