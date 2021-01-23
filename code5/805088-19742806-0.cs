    using (MemoryStream scratch = new MemoryStream())
    {
        using (AesManaged aes = new AesManaged())
        {
            // <snip>
            // Set some aes parameters, including Key, IV, etc.
            // </snip>
            ICryptoTransform encryptor = aes.CreateEncryptor();
            using (CryptoStream myCryptoStream = new CryptoStream(scratch, encryptor, CryptoStreamMode.Write))
            {
                myCryptoStream.Write(someByteArray, 0, someByteArray.Length);
                myCryptoStream.FlushFinalBlock();
                scratch.Flush();   // not sure if this is necessary
                byte[] scratchBytes = scratch.ToArray();
                return Convert.ToBase64String(scratchBytes);
            }
        }
    }
