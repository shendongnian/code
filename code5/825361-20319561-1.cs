    string password = "password";
    SymmetricCrypto c = new SymmetricCrypto();
    string ct = c.EncryptString("payload", password);
    Console.WriteLine(ct); // prints sLSZfzVQGCoML29... (ciphertext will vary)
    string dt = c.DecryptString(ct, password);
    Console.WriteLine(dt); // prints "payload"
