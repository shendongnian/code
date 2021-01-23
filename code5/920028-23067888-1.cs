    private static bool GetPBKDFDerivedKey(string password, 
        byte[] salt,                    // length = 32 bytes (256 bits)
        out byte[] encryptionKeyOut)    // length = 32 bytes (256 bits)
    {            
        IBuffer saltBuffer = CryptographicBuffer.CreateFromByteArray(salt);
        KeyDerivationParameters kdfParameters = KeyDerivationParameters.BuildForPbkdf2(saltBuffer, 10000);  // 10000 iterations
        
        // Get a KDF provider for PBKDF2 and hash the source password to a Cryptographic Key using the SHA256 algorithm.
        // The generated key for the SHA256 algorithm is 256 bits (32 bytes) in length.
        KeyDerivationAlgorithmProvider kdf = KeyDerivationAlgorithmProvider.OpenAlgorithm(KeyDerivationAlgorithmNames.Pbkdf2Sha256);
        IBuffer passwordBuffer = CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8);
        CryptographicKey passwordSourceKey = kdf.CreateKey(passwordBuffer);
        
        // Generate key material from the source password, salt, and iteration count
        const int keySize = 256 / 8;  // 256 bits = 32 bytes  
        IBuffer key = CryptographicEngine.DeriveKeyMaterial(passwordSourceKey, kdfParameters, keySize);
    
        // send the generated key back to the caller
        CryptographicBuffer.CopyToByteArray(key, out encryptionKeyOut);
        
        return true;  // success
    }
