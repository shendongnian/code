    public static string EncryptString(string sData, string sKey)
        {
            // instance of the Rihndael.
            RijndaelManaged RijndaelManagedCipher = new RijndaelManaged();
            // string to byte array.
            byte[] UnicodeText = System.Text.Encoding.Unicode.GetBytes(sData);
            // adign dirt to the string to make it harder to guess using a dictionary attack.
            byte[] Dirty = Encoding.ASCII.GetBytes(sKey.Length.ToString());
            // The Key will be generated from the specified Key and dirt.
            PasswordDeriveBytes FinalKey = new PasswordDeriveBytes(sKey, Dirty);
            // Create a encryptor from the existing FinalKey bytes.           
            ICryptoTransform Encryptor = RijndaelManagedCipher.CreateEncryptor(FinalKey.GetBytes(32), FinalKey.GetBytes(16));
            // Create a MemoryStream that is going to hold the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();
            // Create a CryptoStream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            // write the encryption
            cryptoStream.Write(UnicodeText, 0, UnicodeText.Length);
            // write final blocks to the memory stream
            cryptoStream.FlushFinalBlock();
            // Convert to byte array the encrypted data
            byte[] CipherBytes = memoryStream.ToArray();
            // Close streams.
            memoryStream.Close();
            cryptoStream.Close();
            // Convert to byte array to string
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            // Return the encrypted string
            return EncryptedData;
        }
        public static string DecryptString(string sData, string sKey)
        {
            // instance of rijndael
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            // convert to byte aray the encrypted data
            byte[] EncryptedData = Convert.FromBase64String(sData);
            // add dirt to the key like when encrypthing
            byte[] Dirty = Encoding.ASCII.GetBytes(sKey.Length.ToString());
            // get the finalkey o be used
            PasswordDeriveBytes FinalKey = new PasswordDeriveBytes(sKey, Dirty);
            // Create a decryptor with the key
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(FinalKey.GetBytes(32), FinalKey.GetBytes(16));
            // load to memory stream the encrypted data
            MemoryStream memoryStream = new MemoryStream(EncryptedData);
            // Create a CryptoStream on the memory stream holding the data
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            // Length is unknown but need placeholder big enought for decrypted data
            // we know the decrypted version cannot ever be longer than the crypted version
            // since we added bunch of garbage to it so the length of encrypted data is safe to use
            byte[] UnicodeText = new byte[EncryptedData.Length];
            // Start decrypting
            int DecryptedCount = cryptoStream.Read(UnicodeText, 0, UnicodeText.Length);
            //close streams
            memoryStream.Close();
            cryptoStream.Close();
            // load decrypted data to string
            string DecryptedData = Encoding.Unicode.GetString(UnicodeText, 0, DecryptedCount);
            // Return decrypted string
            return DecryptedData;
        }
