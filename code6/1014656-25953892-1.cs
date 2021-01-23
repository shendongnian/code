    using (var fileStream = targetFile.Create())
    {
        // write random salt
        fileStream.Write(keyGenerator.Salt, 0, SaltSize);
        using (var cryptoStream = new CryptoStream(fileStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bformatter.Serialize(cryptoStream, lines); //changed the input stream to 'cryptoStream'
            cryptoStream.FlushFinalBlock(); //added a call to FlushFinalBlock
        }
    }
