    using System;
    using System.Text;
    using System.Security.Cryptography;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Math.EC;
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto.Parameters;
    public class Bitcoin
    {
      public static ECPoint Recover(byte[] hash, byte[] sigBytes, int rec)
      {
        BigInteger r = new BigInteger(1, sigBytes, 0, 32);
        BigInteger s = new BigInteger(1, sigBytes, 32, 32);
        BigInteger[] sig = new BigInteger[]{ r, s };
        ECPoint Q = ECDSA_SIG_recover_key_GFp(sig, hash, rec, true);
        return Q;
      }
      public static ECPoint ECDSA_SIG_recover_key_GFp(BigInteger[] sig, byte[] hash, int recid, bool check)
      {
        X9ECParameters ecParams = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
        int i = recid / 2;
        BigInteger order = ecParams.N;
        BigInteger x = order.Multiply(new BigInteger(i.ToString())).Add(sig[0]);
        BigInteger field = (ecParams.Curve as FpCurve).Q;
        if (x.CompareTo(field) >= 0) throw new Exception("X too large");
        Console.WriteLine("Order: "+ToHex(order.ToByteArrayUnsigned()));
        Console.WriteLine("Field: "+ToHex(field.ToByteArrayUnsigned()));
        byte[] compressedPoint = new Byte[x.ToByteArrayUnsigned().Length+1];
        compressedPoint[0] = (byte) (0x02+(recid%2));
        Buffer.BlockCopy(x.ToByteArrayUnsigned(), 0, compressedPoint, 1, compressedPoint.Length-1);
        ECPoint R = ecParams.Curve.DecodePoint(compressedPoint);
        Console.WriteLine("R: "+ToHex(R.GetEncoded()));
        if (check)
        {
          ECPoint O = R.Multiply(order);
          if (!O.IsInfinity) throw new Exception("Check failed");
        }
        int n = (ecParams.Curve as FpCurve).Q.ToByteArrayUnsigned().Length*8;
        BigInteger e = new BigInteger(1, hash);
        if (8*hash.Length > n)
        {
          e = e.ShiftRight(8-(n & 7));
        }
        e = BigInteger.Zero.Subtract(e).Mod(order);
        BigInteger rr = sig[0].ModInverse(order);
        BigInteger sor = sig[1].Multiply(rr).Mod(order);
        BigInteger eor = e.Multiply(rr).Mod(order);
        ECPoint Q = ecParams.G.Multiply(eor).Add(R.Multiply(sor));
        Console.WriteLine("n: "+n);
        Console.WriteLine("e: "+ToHex(e.ToByteArrayUnsigned()));
        Console.WriteLine("rr: "+ToHex(rr.ToByteArrayUnsigned()));
        Console.WriteLine("sor: "+ToHex(sor.ToByteArrayUnsigned()));
        Console.WriteLine("eor: "+ToHex(eor.ToByteArrayUnsigned()));
        Console.WriteLine("Q: "+ToHex(Q.GetEncoded());
        return Q;
      }
      public static void Main()
      {
        string msg = "StackOverflow test 123";
        string sig = "IB7XjSi9TdBbB3dVUK4+Uzqf2Pqk71XkZ5PUsVUN+2gnb3TaZWJwWW2jt0OjhHc4B++yYYRy1Lg2kl+WaiF+Xsc=";
        string pubkey = "045894609CCECF9A92533F630DE713A958E96C97CCB8F5ABB5A688A238DEED6DC2D9D0C94EBFB7D526BA6A61764175B99CB6011E2047F9F067293F57F5";
        SHA256Managed sha256 = new SHA256Managed();
        byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(msg), 0, Encoding.UTF8.GetByteCount(msg));
        Console.WriteLine("Hash: "+ToHex(hash));
        byte[] tmpBytes = Convert.FromBase64String(sig);
        byte[] sigBytes = new byte[tmpBytes.Length-1];
        Buffer.BlockCopy(tmpBytes, 1, sigBytes, 0, sigBytes.Length);
        int rec = (tmpBytes[0] - 27) & ~4;
        Console.WriteLine("Rec {0}", rec);
        ECPoint Q = Recover(hash, sigBytes, rec);
        string qstr = ToHex(Q.GetEncoded());
        Console.WriteLine("Q is valid: "+qstr.Equals(pubkey));
      }
      public static string ToHex(byte[] data)
      {
        return BitConverter.ToString(data).Replace("-","");
      }
    }
