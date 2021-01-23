    static string Encrypt(string s)
    {
    	byte[] byteArray = System.Text.Encoding.Unicode.GetBytes(s);
    	string encrypt = BitConverter.ToString(byteArray);
    	return encrypt;
    }
