    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BytePadder
    {
        class Program
        {
            const int p = 61;
            const int q = 53;
            const int n = 3233;
            const int totient = 3120;
            const int e = 991;
            const int d = 1231;
    
            static void Main(string[] args)
            {
                // ---------------------- RSA Example I ----------------------
                // Shows how an integer gets encrypted and decrypted.
                BigInteger integer = 1000;
                BigInteger encryptedInteger = Encrypt(integer);
                Console.WriteLine("Encrypted Integer: {0}", encryptedInteger);
                BigInteger decryptedInteger = Decrypt(encryptedInteger);
                Console.WriteLine("Decrypted Integer: {0}", decryptedInteger);
                // --------------------- RSA Example II ----------------------
                // Shows how a string gets encrypted and decrypted.
                string unencryptedString = "A";
                BigInteger integer2 = new BigInteger(Encoding.UTF8.GetBytes(unencryptedString));
                Console.WriteLine("String as Integer: {0}", integer2);
                BigInteger encryptedInteger2 = Encrypt(integer2);
                Console.WriteLine("String as Encrypted Integer: {0}", encryptedInteger2);
                BigInteger decryptedInteger2 = Decrypt(encryptedInteger2);
                Console.WriteLine("String as Decrypted Integer: {0}", decryptedInteger2);
                string decryptedIntegerAsString = Encoding.UTF8.GetString(decryptedInteger2.ToByteArray());
                Console.WriteLine("Decrypted Integer as String: {0}", decryptedIntegerAsString);
                Console.ReadLine();
            }
    
            static BigInteger Encrypt(BigInteger integer)
            {
                if (integer < n)
                {
                    return BigInteger.ModPow(integer, e, n);
                }
                throw new Exception("The integer must be less than the value of n in order to be decypherable!");
            }
    
            static BigInteger Decrypt(BigInteger integer)
            {
                return BigInteger.ModPow(integer, d, n);
            }
        }
    }
