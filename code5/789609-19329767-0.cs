    public string GetSignature(string text, string password)
    {
        byte[] key;
        byte[] key2;
        GetKeys(password, out key, out key2);
        string sig = encryptstring(GetSHA1(text));
       
    }    
    public void GetKeys(string password, out byte[] key, out byte[] key2)
    {
        byte[] data = StringToByte(password);
        SHA1 sha = new SHA1CryptoServiceProvider();
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] hash1 = sha.ComputeHash(data);
        byte[] hash2 = md5.ComputeHash(data);
        // Generate some key data based on the supplied password;
        byte[] key = new byte[24];
        for (int i = 0; i < 20; i++)
        {
            key[i] = hash1[i];
        }
        for (int i = 0; i < 4; i++)
        {
            key[i + 20] = hash2[i];
        }
        byte[] key2 = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            key2[i] = hash2[i+4];
        }
    }
    public string GetSHA1(string text)
    {
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] hashValue;
        byte[] message = UE.GetBytes(text);
        SHA1Managed hashString = new SHA1Managed();
        string hex = "";
        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;
    }
    public string ByteToString(byte[] buff)
    {
        string sbinary = "";
        for (int i = 0; i < buff.Length; i++)
        {
            sbinary += buff[i].ToString("X2"); // hex format
        }
        return (sbinary);
    }
    public string encryptstring(string instr)
    {
        if (key == null) ResetKey();
        TripleDES threedes = new TripleDESCryptoServiceProvider();
        threedes.Key = key;
        threedes.IV = key2;
        ICryptoTransform encryptor = threedes.CreateEncryptor(key, key2);
        MemoryStream msEncrypt = new MemoryStream();
        CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        // Write all data to the crypto stream and flush it.
        csEncrypt.Write(StringToByte(instr), 0, StringToByte(instr).Length);
        csEncrypt.FlushFinalBlock();
        return ByteToString(msEncrypt.ToArray());
    }
    public string decryptstring(string instr, byte[] key, byte[] key2)
    {
        if (string.IsNullOrEmpty(instr)) return "";
        if (key == null) ResetKey();
        TripleDES threedes = new TripleDESCryptoServiceProvider();
        threedes.Key = key;
        threedes.IV = key2;
        ICryptoTransform decryptor = threedes.CreateDecryptor(key, key2);
        // Now decrypt the previously encrypted message using the decryptor
        MemoryStream msDecrypt = new MemoryStream(HexStringToByte(instr));
        CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        try
        {
            return ByteToString(csDecrypt);
        }
        catch (CryptographicException)
        {
            return "";
        }
    }
