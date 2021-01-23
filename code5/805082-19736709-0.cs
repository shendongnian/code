    CryptoStream myCryptoStream = null;
    try
    {
        using (MemoryStream scratch = new MemoryStream())
        {
            using (AesManaged aes = new AesManaged())
            {
                // <snip>
                // Set some aes parameters, including Key, IV, etc.
                // </snip>
                ICryptoTransform encryptor = aes.CreateEncryptor();
                CryptoStream myCryptoStream = new CryptoStream(scratch, encryptor, CryptoStreamMode.Write);
                try
                {
                    myCryptoStream.Write(someByteArray, 0, someByteArray.Length);
                }
                finally
                {
                    myCryptoStream.FlushFinalBlock();
                }
            }
            // Here, I'm still within the MemoryStream block, so I expect
            // MemoryStream to still be usable.
            scratch.Position = 0;    // Throws ObjectDisposedException
            byte[] scratchBytes = new byte[scratch.Length];
            scratch.Read(scratchBytes,0,scratchBytes.Length);
            return Convert.ToBase64String(scratchBytes);
        }
    }
    finally
    {
        if(myCryptoStream != null)
            myCryptoStream.Dispose();
    }
