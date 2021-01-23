    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.Math.EC;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Crypto.Parameters;
    using System.Text.RegularExpressions;
    
    public static Tuple<byte[], byte[]> GetSecp256k1PublicKey(byte[] privateKey)
            {
                //Secp256k1 curve variables - https://en.bitcoin.it/wiki/Secp256k1
                var privKeyInt = new BigInteger(+1, privateKey);
                var a = new BigInteger("0");
                var b = new BigInteger("7");
                var GX = new BigInteger(+1, HexStringToByteArray("79BE667E F9DCBBAC 55A06295 CE870B07 029BFCDB 2DCE28D9 59F2815B 16F81798"));
                var GY = new BigInteger(+1, HexStringToByteArray("483ADA77 26A3C465 5DA4FBFC 0E1108A8 FD17B448 A6855419 9C47D08F FB10D4B8"));
                var n = new BigInteger(+1, HexStringToByteArray("FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFE BAAEDCE6 AF48A03B BFD25E8C D0364141"));
                var h = new BigInteger("1");
                var p = new BigInteger(+1, HexStringToByteArray("FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFF FFFFFFFE FFFFFC2F"));
                var q = h.Multiply(n).Mod(p); //Is this right???
                //- http://en.wikipedia.org/wiki/Elliptic_curve_cryptography
    
                ECCurve curve = new Org.BouncyCastle.Math.EC.FpCurve(p, a, b);
                ECPoint G = new Org.BouncyCastle.Math.EC.FpPoint(curve, new FpFieldElement(p, GX), new FpFieldElement(p, GY));
                
                var Qa = G.Multiply(privKeyInt);
    
                byte[] PubKeyX = Qa.X.ToBigInteger().ToByteArrayUnsigned();
                byte[] PubKeyY = Qa.Y.ToBigInteger().ToByteArrayUnsigned();
    
                return Tuple.Create<byte[], byte[]>(PubKeyX, PubKeyY);
            }
    
            public static byte[] HexStringToByteArray(string hex)
            {
                if(String.IsNullOrWhiteSpace(hex))
                    return new byte[0];
    
                hex = Regex.Replace(hex, "[\\s-\\{}]", "");
    
                if (hex.Length % 2 == 1)
                    throw new Exception("The binary key cannot have an odd number of digits.");
                
                if (!Regex.IsMatch(hex, "(^|\\A)[0-9A-Fa-f]*(\\Z|$)"))
                    throw new Exception("Not hex.");
    
                byte[] arr = new byte[hex.Length >> 1];
    
                hex = hex.ToUpper();
    
                for (int i = 0; i < hex.Length >> 1; ++i)
                {
                    arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
                }
    
                return arr;
            }
