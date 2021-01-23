      public static void FullSignatureTest(byte[] hash)
      {
        X9ECParameters ecParams = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
        ECDomainParameters domainParameters = new ECDomainParameters(ecParams.Curve,
                                                                     ecParams.G, ecParams.N, ecParams.H,
                                                                     ecParams.GetSeed());
        ECKeyGenerationParameters keyGenParams =
          new ECKeyGenerationParameters(domainParameters, new SecureRandom());
        AsymmetricCipherKeyPair keyPair;
        ECKeyPairGenerator generator = new ECKeyPairGenerator();
        generator.Init(keyGenParams);
        keyPair = generator.GenerateKeyPair();
        ECPrivateKeyParameters privateKey = (ECPrivateKeyParameters) keyPair.Private;
        ECPublicKeyParameters publicKey = (ECPublicKeyParameters) keyPair.Public;
        Console.WriteLine("Generated private key: " + ToHex(privateKey.D.ToByteArrayUnsigned()));
        Console.WriteLine("Generated public key: " + ToHex(publicKey.Q.GetEncoded()));
        ECDsaSigner signer = new ECDsaSigner();
        signer.Init(true, privateKey);
        BigInteger[] sig = signer.GenerateSignature(hash);
        int recid = -1;
        for (int rec=0; rec<4; rec++) {
          try
          {
            ECPoint Q = ECDSA_SIG_recover_key_GFp(sig, hash, rec, true);
            if (ToHex(publicKey.Q.GetEncoded()).Equals(ToHex(Q.GetEncoded())))
            {
              recid = rec;
              break;
            }
          }
          catch (Exception)
          {
            continue;
          }
        }
        if (recid < 0) throw new Exception("Did not find proper recid");
        byte[] fullSigBytes = new byte[65];
        fullSigBytes[0] = (byte) (27+recid);
        Buffer.BlockCopy(sig[0].ToByteArrayUnsigned(), 0, fullSigBytes, 1, 32);
        Buffer.BlockCopy(sig[1].ToByteArrayUnsigned(), 0, fullSigBytes, 33, 32);
        Console.WriteLine("Generated full signature: " + Convert.ToBase64String(fullSigBytes));
        byte[] sigBytes = new byte[64];
        Buffer.BlockCopy(sig[0].ToByteArrayUnsigned(), 0, sigBytes, 0, 32);
        Buffer.BlockCopy(sig[1].ToByteArrayUnsigned(), 0, sigBytes, 32, 32);
        ECPoint genQ = ECDSA_SIG_recover_key_GFp(sig, hash, recid, false);
        Console.WriteLine("Generated signature verifies: " + VerifySignature(genQ.GetEncoded(), hash, sigBytes));
      }
