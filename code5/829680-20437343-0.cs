    using System;
    using System.Linq;
    using System.Security.Cryptography;
    public class RNGStringProvider
    {
        private static readonly char[] Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToArray();
        public string GetString(int length)
        {
            string chars = "";
            for (int i = 0; i < length; i++)
            {
                var rng = new RNGCryptoServiceProvider();
                var bits = new Byte[1];
                do { rng.GetNonZeroBytes(bits); } while (bits[0] > 248);
                chars += Characters[bits[0] % 62];
            }
            return chars;
        }
    }
    // Type in the number of characters you wish to generate, this example creates 20.
    var randomString = new RNGStringProvider().GetString(20); 
