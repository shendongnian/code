    MemoryStream scratch = null;
    AesManaged aes = null;
    CryptoStream myCryptoStream = null;
    try
    {
        scratch = new MemoryStream();
        aes = new AesManaged();
        
        // <snip>
        // Set some aes parameters, including Key, IV, etc.
        // </snip>
        ICryptoTransform encryptor = aes.CreateEncryptor();
        myCryptoStream = new CryptoStream(scratch, encryptor, CryptoStreamMode.Write);
        myCryptoStream.Write(someByteArray, 0, someByteArray.Length);
        
        //Flush the data out so it is fully written to the underlying stream.
        myCryptoStream.FlushFinalBlock();
           
        scratch.Position = 0; 
        byte[] scratchBytes = new byte[scratch.Length];
        scratch.Read(scratchBytes,0,scratchBytes.Length);
        return Convert.ToBase64String(scratchBytes);
    }
    finally
    {
        //Dispose all of the disposeable objects we created in reverse order.
        if(myCryptoStream != null)
            myCryptoStream.Dispose();
        if(aes != null)
            aes.Dispose();
        if(scratch != null)
            scratch.Dispose();
    }
