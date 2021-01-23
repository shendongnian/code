    string str = "abcdefghijklmno|axXXyyYY343433553353afsafaadfafdfsafsf|2013-01-01T00:00:00";
    byte[] data = Encoding.UTF8.GetBytes(str);
    byte[] key = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }; // Your random key, I hope more random!
    byte[] encrypted;
    // Encrypt
    using (var am = new AesManaged())
    using (var rng = new RNGCryptoServiceProvider())
    {
        am.Key = key;
        var iv = new byte[am.BlockSize / 8];
        rng.GetBytes(iv);
        am.IV = iv;
        using (var encryptor = am.CreateEncryptor())
        using (var ms = new MemoryStream())
        {
            ms.Write(iv, 0, iv.Length);
            using (var encStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                encStream.Write(data, 0, data.Length);
            }
            encrypted = ms.ToArray();
        }
    }
    // Decrypt
    string str2;
    using (var am = new AesManaged())
    using (var ms = new MemoryStream(encrypted))
    {
        am.Key = key;
            
        var iv = new byte[am.BlockSize / 8];
        ms.Read(iv, 0, iv.Length);
        am.IV = iv;
        using (var decryptor = am.CreateDecryptor())
        using (var decStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
        using (var ms2 = new MemoryStream())
        {
            decStream.CopyTo(ms2);
            str2 = Encoding.UTF8.GetString(ms2.GetBuffer(), 0, (int)ms2.Length);
        }
    }
