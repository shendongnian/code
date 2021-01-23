    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DES_Encryption
    {
        class DES_Class
        {
            public static void EncryptAndSaveFile(string InputFilePath, string OutputFilePath, byte[] Key, byte[] IV)
            {
                if (((InputFilePath.Length <= 0 || InputFilePath == null) || (Key.Length <= 0 || Key == null) || (IV.Length <= 0 || IV == null)))
                    throw new Exception("All Values must be filled");
    
                using (FileStream fileCrypt = new FileStream(OutputFilePath, FileMode.Create))
                {
                    using (DESCryptoServiceProvider encrypt = new DESCryptoServiceProvider())
                    {
                        using (CryptoStream cs = new CryptoStream(fileCrypt, encrypt.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                        {
                            using (FileStream fileInput = new FileStream(InputFilePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fileInput.ReadByte()) != -1)
                                    cs.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
    
    
            public static void DecryptAndSaveFile(string InputFilePath, string OutputFilePath, byte[] Key, byte[] IV)
            {
                if (((InputFilePath.Length <= 0 || InputFilePath == null) || (OutputFilePath.Length <= 0 || OutputFilePath == null) 
                    || (Key.Length <= 0 || Key == null) || (IV.Length <= 0 || IV == null)))
                    throw new Exception("All Values must be filled");
    
                using (FileStream fileCrypt = new FileStream(OutputFilePath, FileMode.Create))
                {
                    using (DESCryptoServiceProvider decrypt = new DESCryptoServiceProvider())
                    {
                        using (CryptoStream cs = new CryptoStream(fileCrypt, decrypt.CreateDecryptor(Key, IV), CryptoStreamMode.Write))
                        {
                            using (FileStream fileInput = new FileStream(InputFilePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fileInput.ReadByte()) != -1)
                                    cs.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
    
            public static byte[] DecryptFileAndReturnStream(string InputFilePath, byte[] Key, byte[] IV)
            {
                if (((InputFilePath.Length <= 0 || InputFilePath == null) || (Key.Length <= 0 || Key == null) || (IV.Length <= 0 || IV == null)))
                    throw new Exception("All Values must be filled");
    
                using (MemoryStream stream = new MemoryStream())
                {
                    using (DESCryptoServiceProvider decrypt = new DESCryptoServiceProvider())
                    {
                        using (CryptoStream cs = new CryptoStream(stream, decrypt.CreateDecryptor(Key, IV), CryptoStreamMode.Write))
                        {
                            using (FileStream fileInput = new FileStream(InputFilePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fileInput.ReadByte()) != -1)
                                    cs.WriteByte((byte)data);
                            }
                        }
                    }
                    return stream.ToArray();
                }
            }
    
    
            public static byte[] StringToByteArray(string cipher)
            {
                byte[] ByteArray = Encoding.ASCII.GetBytes(cipher);
                return ByteArray;
            }
    
            public static string ByteArrayToString(byte[] arr)
            {
                string ASCII = Encoding.ASCII.GetString(arr);
                return ASCII;
            }
        }
    }
