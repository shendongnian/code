    private string EncryptSymmetricToBase64(SymmetricAlgorithm symAlg, string plainText)
    {
        using (var ms = new MemoryStream())
        {
            using (var cs = new CryptoStream(ms, symAlg.CreateEncryptor(symAlg.Key, symAlg.IV), CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }
            string ciphered = Convert.ToBase64String(ms.ToArray());
            return ciphered;
        }
    }
