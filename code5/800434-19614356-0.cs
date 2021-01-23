    public static byte[] Encrypt(byte[] plaintext, byte[] key)
    {
        using (var aes = Aes.Create())
        {
            aes.BlockSize = 128;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.None;
            var encryptor = aes.CreateEncryptor(key, new byte[16]);
            using(var target = new MemoryStream())
            using (var cs = new CryptoStream(target, encryptor, CryptoStreamMode.Write))
            {
                cs.Write(plaintext, 0, plaintext.Length);
                return target.ToArray();
            }
        }
    }
