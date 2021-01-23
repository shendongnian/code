    public static void DecryptStringFromBytes(byte[] cipherText, byte[] Key, Stream stream)
    {
       // ...
       // Don't use StreamReader
       csDecrypt.CopyTo(stream)
       // ...
    }
