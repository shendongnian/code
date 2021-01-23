    var lst = new List<string> {
        "Foo",
        "Bar",
        "FooBarFooBarFooBarFooBar",
        "FooBar",
    };
    MemoryStream ms = new MemoryStream();
    var aesInstance = new AesCtr();
    ICryptoTransform encryptor = aesInstance.CreateEncryptor(aesInstance.Key, aesInstance.IV);
    foreach (var str in lst)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        byte[] length = BitConverter.GetBytes(bytes.Length);
        byte[] encryptedLength = encryptor.TransformFinalBlock(length, 0, length.Length);
        byte[] encryptedBytes = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        ms.Write(encryptedLength, 0, encryptedLength.Length);
        ms.Write(encryptedBytes, 0, encryptedBytes.Length);
    }
    ms.Position = 0;
    ICryptoTransform decryptor = aesInstance.CreateDecryptor(aesInstance.Key, aesInstance.IV);
    while (ms.Position < ms.Length)
    {
        byte[] encryptedLength = new byte[4];
        int read = ms.Read(encryptedLength, 0, encryptedLength.Length);
        if (read < encryptedLength.Length)
        {
            throw new Exception();
        }
        byte[] length = decryptor.TransformFinalBlock(encryptedLength, 0, encryptedLength.Length);
        int length2 = BitConverter.ToInt32(length, 0);
        byte[] encryptedBytes = new byte[length2];
        read = ms.Read(encryptedBytes, 0, encryptedBytes.Length);
        if (read < encryptedBytes.Length)
        {
            throw new Exception();
        }
        byte[] bytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        string str = Encoding.UTF8.GetString(bytes);
        Console.WriteLine("Encrypted: {0} bytes, value: {1}", encryptedBytes.Length, str);
    } 
