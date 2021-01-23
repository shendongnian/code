    public static string OpenSSLDecrypt(string encrypted, string passphrase)
    {
        //get the key bytes (not sure if UTF8 or ASCII should be used here doesn't matter if no extended chars in passphrase)
        var key = Encoding.UTF8.GetBytes(passphrase);
        //pad key out to 32 bytes (256bits) if its too short
        if (key.Length < 32)
        {
            var paddedkey = new byte[32];
            Buffer.BlockCopy(key, 0, paddedkey, 0, key.Length);
            key = paddedkey;
        }
        //setup an empty iv
        var iv = new byte[16];
        //get the encrypted data and decrypt
        byte[] encryptedBytes = Convert.FromBase64String(encrypted);
        return DecryptStringFromBytesAes(encryptedBytes, key, iv);
    }
