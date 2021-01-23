    string stringToEncrypt = "Mary had a little lamb.";
    Console.WriteLine("Encrypting the string: {0}", stringToEncrypt);
    byte[] encryptedBytes = engine.Encrypt(stringToEncrypt, Encoding.UTF8);
    Console.WriteLine("Encrypted text: {0}", Encoding.UTF8.GetString(encryptedBytes));
    Console.WriteLine("Decrypted text: {0}", engine.Decrypt(encryptedBytes, Encoding.UTF8));
