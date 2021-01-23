    var message = "whatever you want";
    // privateKey is a byte[] of length 64
    // publicKey is a byte[] of length 32
    // get a signature for the message
    var signature = PublicKeyAuth.SignDetached(message, privateKey);
    // check the signature for the message
    if (PublicKeyAuth.VerifyDetached(signature, message, publicKey))
    {
        // message ok
    }
