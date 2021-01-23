    using (var aes = new AesManaged())
    {
        var iv = aes.IV;   // Gets the initialization vector (IV) to use for the symmetric algorithm.
        var key = aes.Key; // Gets or sets the secret key used for the symmetric algorithm. Set the Key if you don't like the generated one.
    }
