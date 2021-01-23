    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MessageHashTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum id urn";
                string secret = "5771CC06-B86D-41A6-AB39-9CA2BA338E27";
    
                var encoding = new System.Text.ASCIIEncoding();
                byte[] keyByte = encoding.GetBytes(secret);
                byte[] messageBytes = encoding.GetBytes(message);
                using (var hmacsha256 = new HMACSHA256(keyByte))
                {
                    byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                    Console.WriteLine(Convert.ToBase64String(hashmessage));
                }
            }
        }
    }
