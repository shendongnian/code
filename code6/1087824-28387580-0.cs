    public static RSAParameters ToRSAParameters(RsaPrivateCrtKeyParameters privKey)
    {
       RSAParameters rp = new RSAParameters();
       rp.Modulus = privKey.Modulus.ToByteArrayUnsigned();
       rp.Exponent = privKey.PublicExponent.ToByteArrayUnsigned();
       rp.P = privKey.P.ToByteArrayUnsigned();
       rp.Q = privKey.Q.ToByteArrayUnsigned();
       rp.D = ConvertRSAParametersField(privKey.Exponent, rp.Modulus.Length);
       rp.DP = ConvertRSAParametersField(privKey.DP, rp.P.Length);
       rp.DQ = ConvertRSAParametersField(privKey.DQ, rp.Q.Length);
       rp.InverseQ = ConvertRSAParametersField(privKey.QInv, rp.Q.Length);
       return rp;
    }
    
    private static byte[] ConvertRSAParametersField(BigInteger n, int size)
    {
       byte[] bs = n.ToByteArrayUnsigned();
       if (bs.Length == size)
          return bs;
       if (bs.Length > size)
          throw new ArgumentException("Specified size too small", "size");
       byte[] padded = new byte[size];
       Array.Copy(bs, 0, padded, size - bs.Length, bs.Length);
       return padded;
    }
