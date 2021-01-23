    public string GetSHAEncryptedCode(string Text)
    {
        //SHA1 sha26 = new SHA1CryptoServiceProvider();
        SHA256 sha26 = new SHA256CryptoServiceProvider();
        byte[] sha256Bytes = System.Text.Encoding.UTF8.GetBytes(Text);
        byte[] cryString = sha26.ComputeHash(sha256Bytes);
        string sha256Str = string.Empty;
        for (int i = 0; i < cryString.Length; i++)
        {
            sha256Str += cryString[i].ToString("X2");
        }
        return sha256Str;
    }
