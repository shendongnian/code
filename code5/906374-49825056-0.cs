    using System;
    using System.Security.Cryptography;
    using System.Security.Permissions;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Byte[] bytes = File.ReadAllBytes(@"D:\tmp\111111111111.p12");
                X509Certificate2 x509 = new X509Certificate2(bytes, "qwerty", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                var privateKey = x509.PrivateKey as RSACryptoServiceProvider;
                string uniqueKeyContainerName = privateKey.CspKeyContainerInfo.UniqueKeyContainerName;
                x509.Reset();
    
                File.Delete(string.Format(@"C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys\{0}", uniqueKeyContainerName));
            }
        }
    }
