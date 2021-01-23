    private static readonly Org.BouncyCastle.Asn1.X9.X9ECParameters curve = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256r1");
    private static readonly Org.BouncyCastle.Crypto.Parameters.ECDomainParameters domain = new Org.BouncyCastle.Crypto.Parameters.ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H);
    public string GetPublicKey(string privKey)
    {
          Org.BouncyCastle.Math.BigInteger d = new Org.BouncyCastle.Math.BigInteger(Convert.FromBase64String(privKey));
          //var privKeyParameters = new Org.BouncyCastle.Crypto.Parameters.ECPrivateKeyParameters(d, domain);
          Org.BouncyCastle.Math.EC.ECPoint q = domain.G.Multiply(d);
          //var pubKeyParameters = new Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters(q, domain);
          return Convert.ToBase64String(q.GetEncoded());
    }
