    var lst = new List<string> {
        "Foo",
        "Bar",
        "FooBarFooBarFooBarFooBar",
        "FooBar",
    };
    MemoryStream ms = new MemoryStream();
    var aesInstance = Aes.Create();
    foreach (var str in lst)
    {
        ICryptoTransform encryptor = aesInstance.CreateEncryptor(aesInstance.Key, aesInstance.IV);
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        byte[] encrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        byte[] length = BitConverter.GetBytes(encrypted.Length);
        ms.Write(length, 0, length.Length);
        ms.Write(encrypted, 0, encrypted.Length);
    }
    ms.Position = 0;
    while (ms.Position < ms.Length)
    {
        ICryptoTransform decryptor = aesInstance.CreateDecryptor(aesInstance.Key, aesInstance.IV);
        byte[] length = new byte[4];
        int read = ms.Read(length, 0, length.Length);
        if (read < length.Length)
        {
            throw new Exception();
        }
        int length2 = BitConverter.ToInt32(length, 0);
        byte[] encrypted = new byte[length2];
        read = ms.Read(encrypted, 0, encrypted.Length);
        if (read < encrypted.Length)
        {
            throw new Exception();
        }
        byte[] decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
        string str = Encoding.UTF8.GetString(decrypted);
        Console.WriteLine("Encrypted: {0} bytes, value: {1}", encrypted.Length, str);
    }
