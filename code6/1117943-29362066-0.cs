    public byte[] TripleDes(byte[] inputBuffer, byte[] key)
    {
        using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider())
        {
            des.Key = key;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.None;
            byte[] result;
            using (MemoryStream stream = new MemoryStream())
            using (CryptoStream cryptoStream = new CryptoStream(stream, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(inputBuffer, 0, inputBuffer.Length);
                cryptoStream.Flush();
                //cryptoStream.FlushFinalBlock();
                result = stream.ToArray();
            }
            return result;
        }
    }
