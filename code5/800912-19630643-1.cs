    byte[] bytes = StringToByteArray(_key);
    using(DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider())
    {
        cryptoProvider.Padding = PaddingMode.None;
        cryptoProvider.Mode = CipherMode.ECB;
        using(var crypter =  cryptoProvider.CreateDecryptor(bytes, new byte[8]))
        {
            return crypter.TransformFinalBlock(bytes, 0, bytes.Length);
        }
    }
