    public static string Encrypt2(string clearText,string key)
    {
    	try
    	{
    		string encryptedText = "";
    		MD5 md5 = new MD5CryptoServiceProvider();
    		TripleDES des = new TripleDESCryptoServiceProvider();
    		des.KeySize = 128;
    		des.Mode = CipherMode.CBC;
    		des.Padding = PaddingMode.PKCS7;
    
    		byte[] md5Bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
    
    		byte[] ivBytes = new byte[8];
    
    
    		des.Key = md5Bytes;
    
    		des.IV = ivBytes;
    
    		byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
    
    		ICryptoTransform ct = des.CreateEncryptor();
    		using (MemoryStream ms = new MemoryStream())
    		{
    			using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
    			{
    				cs.Write(clearBytes, 0, clearBytes.Length);
    				cs.Close();
    			}
    			encryptedText = Convert.ToBase64String(ms.ToArray());
    		}
    		return encryptedText;
    	}
    	catch (Exception exception)
    	{
    		return "";
    	}
    }
