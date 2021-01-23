    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    
    class Test
    {
        const int p = 61;
        const int q = 53;
        const int n = 3233;
        const int totient = 3120;
        const int e = 991;
        const int d = 1231;
        
        static void Main()
        {
            var encrypted = Encrypt("Hello, world.", Encoding.UTF8);
            var decrypted = Decrypt(encrypted, Encoding.UTF8);
            Console.WriteLine(decrypted);
        }
        
        static BigInteger[] Encrypt(string text, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(text);
            return bytes.Select(b => BigInteger.ModPow(b, (BigInteger)e, n))
                        .ToArray();
        }
    
        static string Decrypt(BigInteger[] encrypted, Encoding encoding)
        {
            byte[] bytes = encrypted.Select(bi => (byte) BigInteger.ModPow(bi, d, n))
                                    .ToArray();
            return encoding.GetString(bytes);
        }
    }
