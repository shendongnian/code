    private IEnumerable<byte[]> DecryptFiles(IEnumerable<string> inputFiles, string skey)
    {
        //Only performing the key calculation once.
        Rfc2898DeriveBytes k2 = new Rfc2898DeriveBytes(skey, new byte[] { 10, 10, 10, 10, 10, 10, 10, 10 });
        byte[] key = k2.GetBytes(16)
    
        foreach(var inputFile in inputFiles)
        {
            yield return DecryptFile(inputFile, key);
        }
    }
    
    private byte[] DecryptFile(string inputFile, byte[] key)
    {
        var output1 = new MemoryStream();
        try
        {
            //If you are going to use AES, then use AES, also the CSP is faster than the managed version.
            using (var aes = new AesCryptoServiceProvider ())
            {
                //No need to copy the file in to memory first, just read it from the hard drive.
                using(var fsCrypt = File.OpenRead(inputFile))
                {
                    //Gets the IV from the header of the file, you will need to modify your Encrypt process to write it.
                    byte[] IV = GetIV(fsCrypt);
    
                    //You can chain consecutive using statements like this without brackets.
                    using (var decryptor = aes.CreateDecryptor(key, IV))
                    using (var cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                    {
                        cs.CopyTo(output1);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        
        return output1.ToArray();
    }
    
    //This function assumes you wrote a 32 bit length then the array that was the read length long.
    private static byte[] GetIV(Stream fileStream)
    {
        var reader = new BinaryReader(fileStream);
        var keyLength = reader.ReadInt32();
        return reader.ReadBytes(keyLength);
    }
