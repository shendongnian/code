      var privateKey = PrivateKeyFactory.CreateKey(bytes) as ECPrivateKeyParameters;
      if (privateKey == null)
           return null;
      Org.BouncyCastle.Math.EC.ECPoint q = privateKey.Parameters.G.Multiply(privateKey.D);
      var publicParams = new ECPublicKeyParameters(privateKey.AlgorithmName, q, privateKey.PublicKeyParamSet);
      return SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicParams).GetDerEncoded();
