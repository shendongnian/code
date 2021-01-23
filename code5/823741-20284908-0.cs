    var privKeyObj = Asn1Object.FromStream(privatekey);
    var privStruct = new RsaPrivateKeyStructure((Asn1Sequence)privKeyObj);
    
    // Conversion from BouncyCastle to .Net framework types
    var rsaParameters = new RSAParameters();
    rsaParameters.Modulus = privStruct.Modulus.ToByteArrayUnsigned();
    rsaParameters.Exponent = privStruct.PublicExponent.ToByteArrayUnsigned();
    rsaParameters.D = privStruct.PrivateExponent.ToByteArrayUnsigned();
    rsaParameters.P = privStruct.Prime1.ToByteArrayUnsigned();
    rsaParameters.Q = privStruct.Prime2.ToByteArrayUnsigned();
    rsaParameters.DP = privStruct.Exponent1.ToByteArrayUnsigned();
    rsaParameters.DQ = privStruct.Exponent2.ToByteArrayUnsigned();
    rsaParameters.InverseQ = privStruct.Coefficient.ToByteArrayUnsigned();
    var rsa = new RSACryptoServiceProvider();
    rsa.ImportParameters(rsaParameters);
    return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(ciphertext), true));
