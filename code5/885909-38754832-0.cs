    using Org.BouncyCastle.Asn1.Sec;
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Math.EC;
    
    public static class Example
    {
        private static X9ECParameters curve = SecNamedCurves.GetByName("secp256k1");
        private static ECDomainParameters domain = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H);
    
        public static byte[] ToPublicKey(byte[] privateKey)
        {
            BigInteger d = new BigInteger(privateKey);
            ECPoint q = domain.G.Multiply(d);
            var publicParams = new ECPublicKeyParameters(q, domain);
            return publicParams.Q.GetEncoded();
        }
    }
