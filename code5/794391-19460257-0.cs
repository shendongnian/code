    using System;
    using System.IO;
    using System.Security.Cryptography;
    
    namespace ConsoleApplication12
    {
        class Program
        {
            private const int KEY_SIZE_BYTES = 32;
            private const int IV_SIZE_BYTES = 16;
    
            static void Main(string[] args)
            {
                var rand = new Random();
                using (var fs = File.Open(@"C:\temp\input.bin", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    byte[] buffer = new byte[10000];
                    for (int i = 0; i < 100; ++i)
                    {
                        rand.NextBytes(buffer);
                        fs.Write(buffer, 0, buffer.Length);
                    }
                }
                string key = GenerateRandomKey();
                Encrypt(@"C:\temp\input.bin", @"C:\temp\encrypted.bin", key);
                Decrypt(@"C:\temp\encrypted.bin", @"C:\temp\decyrypted.bin", key);
            }
    
            static string GenerateRandomKey()
            {
                byte[] key = new byte[KEY_SIZE_BYTES];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(key);
                }
                return Convert.ToBase64String(key);
            }
    
            static void Encrypt(string inputFile, string outputFile, string key)
            {
                const int BUFFER_SIZE = 8192;
                byte[] buffer = new byte[BUFFER_SIZE];
                byte[] keyBytes = Convert.FromBase64String(key);
                byte[] ivBytes = new byte[IV_SIZE_BYTES];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(ivBytes);
                }
                using (var inputStream = File.Open(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var outputStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        outputStream.Write(ivBytes, 0, ivBytes.Length);
                        using (var cryptoAlgo = Aes.Create())
                        {
                            using (var encryptor = cryptoAlgo.CreateEncryptor(keyBytes, ivBytes))
                            {
                                using (var cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                                {
                                    int count;
                                    while ((count = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        cryptoStream.Write(buffer, 0, count);
                                    }
                                }
                            }
                        }
                    }
                }
            }
    
            static void Decrypt(string inputFile, string outputFile, string key)
            {
                const int BUFFER_SIZE = 8192;
                byte[] buffer = new byte[BUFFER_SIZE];
                byte[] keyBytes = Convert.FromBase64String(key);
                byte[] ivBytes = new byte[IV_SIZE_BYTES];
                using (var inputStream = File.Open(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    inputStream.Read(ivBytes, 0, ivBytes.Length);
                    using (var outputStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (var cryptoAlgo = Aes.Create())
                        {
                            using (var decryptor = cryptoAlgo.CreateDecryptor(keyBytes, ivBytes))
                            {
                                using (var cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                                {
                                    int count;
                                    while ((count = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        outputStream.Write(buffer, 0, count);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
