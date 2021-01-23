    var message = @"Meet me at the secret location at 8pm";
    var iv = @"4QesEr03HwE5H1C+ICw7SA==";
    var key = @"ovA6siPkyM5Lb9oNcnxLz676K6JK6FrJKk4efEUWBzg=";
    byte[] encryptedBytes;
    using (RijndaelManaged myRijndael = new RijndaelManaged())
    {
        myRijndael.IV = Convert.FromBase64String(iv);
        myRijndael.Key = Convert.FromBase64String(key);
        myRijndael.Padding = PaddingMode.PKCS7;
        myRijndael.Mode = CipherMode.CBC;
        using (var encryptor = myRijndael.CreateEncryptor())
        using (var memoryStream = new MemoryStream())
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        using (var streamWriter = new StreamWriter(cryptoStream))
        {
            streamWriter.Write(message);
            streamWriter.Close();
            encryptedBytes = memoryStream.ToArray();
        }
    }
    var encryptedMessage = Convert.ToBase64String(encryptedBytes);
    Console.WriteLine(encryptedMessage);
    using (RijndaelManaged myRijandael = new RijndaelManaged())
    {
        myRijandael.IV = Convert.FromBase64String(iv);
        myRijandael.Key = Convert.FromBase64String(key);
        myRijandael.Padding = PaddingMode.PKCS7;
        myRijandael.Mode = CipherMode.CBC;
        using (var decryptor = myRijandael.CreateDecryptor())
        using (var memoryStream = new MemoryStream(Convert.FromBase64String(encryptedMessage)))
        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        using (var streamReader = new StreamReader(cryptoStream))
        {
            Console.WriteLine(streamReader.ReadToEnd());
        }
    }
