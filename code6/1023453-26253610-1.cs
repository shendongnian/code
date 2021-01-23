    var message = @"Meet me at the secret location at 8pm";
    var iv = @"4QesEr03HwE5H1C+ICw7SA==";
    var key = @"ovA6siPkyM5Lb9oNcnxLz676K6JK6FrJKk4efEUWBzg=";
    byte[] encryptedBytes;
    using (var aesCryptoProvider = new AesCryptoServiceProvider())
    {
        aesCryptoProvider.BlockSize = 128;
        aesCryptoProvider.KeySize = 256;
        aesCryptoProvider.IV = Convert.FromBase64String(iv);
        aesCryptoProvider.Key = Convert.FromBase64String(key);
        aesCryptoProvider.Padding = PaddingMode.PKCS7;
        aesCryptoProvider.Mode = CipherMode.CBC;
        using (var encryptor = aesCryptoProvider.CreateEncryptor())
        using (var memoryStream = new MemoryStream())
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        using (var streamWriter = new StreamWriter(cryptoStream, Encoding.UTF8))
        {
            streamWriter.Write(message);
            streamWriter.Close();
            encryptedBytes = memoryStream.ToArray();
        }
    }
    var encryptedMessage = Convert.ToBase64String(encryptedBytes);
    Console.WriteLine(encryptedMessage);
    using (var aesCryptoProvider = new AesCryptoServiceProvider())
    {
        aesCryptoProvider.BlockSize = 128;
        aesCryptoProvider.KeySize = 256;
        aesCryptoProvider.IV = Convert.FromBase64String(iv);
        aesCryptoProvider.Key = Convert.FromBase64String(key);
        aesCryptoProvider.Padding = PaddingMode.PKCS7;
        aesCryptoProvider.Mode = CipherMode.CBC;
        using (var decryptor = aesCryptoProvider.CreateDecryptor())
        using (var memoryStream = new MemoryStream(Convert.FromBase64String(encryptedMessage)))
        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        using (var streamReader = new StreamReader(cryptoStream, Encoding.UTF8))
        {
            Console.WriteLine(streamReader.ReadToEnd());
        }
    }
