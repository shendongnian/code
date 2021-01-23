    byte[] ds = new byte[data.Length];
    byte[] decryptedData;
    using (Aes aes = CreateAes(key, iv, cipherMode, paddingMode))
    {
        using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
        {
            int i = 0;
            using (MemoryStream msDecrypt = new MemoryStream(data))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    int k;
                    while ((k = csDecrypt.ReadByte()) != -1)
                    {
                        ds[i++] = (byte)k;
                    }
                }
            }
            decryptedData = new byte[i];
            Buffer.BlockCopy(ds, 0, decryptedData, 0, i);
        }
    }
    return decryptedData;
