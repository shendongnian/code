    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    
    namespace Test
    {
    
        static class Extensions
        {
            public static IEnumerable<String> SplitParts(this string text, int length)
            {
                for (var i = 0; i < text.Length; i += length)
                    yield return text.Substring(i, Math.Min(length, text.Length - i));
            }
        }
    
        static class Program
        {
            static void Main()
            {
                RSA rsaObj = RSA.Create();
                RSAParameters rsaParas = rsaObj.ExportParameters(false);
                byte[] eByte = rsaParas.Exponent;
                byte[] nByte = rsaParas.Modulus;
    
                //convert to decimal string
                var eByteString = eByte.Aggregate(string.Empty, (current, n) => current + n.ToString("000"));
                var nByteString = nByte.Aggregate(string.Empty, (current, n) => current + n.ToString("000"));
    
                //convert back to array
                var arrEByteString = eByteString.SplitParts(3).Select(s => Convert.ToByte(s)).ToArray();
                var arrNByteString = nByteString.SplitParts(3).Select(s => Convert.ToByte(s)).ToArray();
            }
        }
    }
