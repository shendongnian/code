    var rfc = new Rfc2898DeriveBytes(key, saltBytes);
        using (var cryptoProvider = new AesManaged())
        {
            // Set cryptoProvider parameters
            cryptoProvider.BlockSize = cryptoProvider.LegalBlockSizes[0].MaxSize;
            cryptoProvider.KeySize = cryptoProvider.LegalKeySizes[0].MaxSize;
            cryptoProvider.Key = rfc.GetBytes(cryptoProvider.KeySize / 8);
            cryptoProvider.IV = rfc.GetBytes(cryptoProvider.BlockSize / 8);
        }
    Console.Writeline(Convert.ToBase64(cryptoProvider.Key));
    Console.Writeline(Convert.ToBase64(cryptoProvider.IV));
    $123456789101112134==
    $600200300==
