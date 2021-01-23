    public string DecryptStringFromBytes_Aes(byte[] cipherText, string Key)
    {
        // Check arguments. 
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
    
        // Create an Aes object 
        // with the specified key and IV. 
    
        // Create the streams used for decryption. 
    
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;
            //Grab IV from ciphertext
            byte[] IV = new byte[16];
            Array.Copy(cipherText,0,IV,0,16);
            //Use the IV for the Salt
            byte[] theSalt = new byte[8];
            Array.Copy(IV,theSalt,8);
            Rfc2898DeriveBytes keyGen = new Rfc2898DeriveBytes(Key,theSalt);
            byte[] aesKey = keyGen.GetBytes(16);
            aesAlg.Key = aesKey;
    
            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, IV);
    
            //You can chain using statements like this to make the code easier to read.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) //Notice this is Read mode not Write mode.
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                //Decrypt the ciphertext
                return srDecrypt.ReadToEnd();
            }  
        }
    }
