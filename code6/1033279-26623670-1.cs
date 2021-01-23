    static string Encrypt(string s)
    {
    	string encrypt = "";
    	byte[] byteArray = System.Text.Encoding.Unicode.GetBytes(s);
    	foreach (byte b in byteArray)
    	{
    		encrypt += String.Format("{0:x}", System.Convert.ToInt64(b));
    	}
    	return encrypt;
    }
