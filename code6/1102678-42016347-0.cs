    RsaKeyParameters key = (RsaKeyParameters)cert.GetPublicKey();
    
    // Construct a microsoft RSA crypto service provider using the public key in the certificate
    RSAParameters param = new RSAParameters();
    param.Exponent = key.Exponent.ToByteArrayUnsigned();
    param.Modulus = key.Modulus.ToByteArrayUnsigned();
