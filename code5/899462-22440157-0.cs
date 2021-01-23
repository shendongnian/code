    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                String cryptedText = "debac58d0bc8526339678667bca923e15a7106a0c16c8148bd1468cefad57762ccf53a4a780bc27748c5583a02c41dee";
                String key = "qwertyuioplkjhgfdsaz";
                Console.WriteLine("Crypted Text = " + cryptedText);
                Console.WriteLine("Key = " + key);
                Console.WriteLine("Decrypted = " + Decrypt(cryptedText, key));
                Console.ReadKey();
            }
    
            public static string Decrypt(string toDecrypt, string key)
            {
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key); // AES-256 key
                PadToMultipleOf(ref keyArray, 8);
                //byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                byte[] toEncryptArray = ConvertHexStringToByteArray(toDecrypt);
    
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.KeySize = (keyArray.Length * 8);
                rDel.Key = keyArray;          // in bits
                rDel.Mode = CipherMode.ECB; // http://msdn.microsoft.com/en-us/library/system.security.cryptography.ciphermode.aspx
                rDel.Padding = PaddingMode.None;  // better lang support
                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
    
            public static void PadToMultipleOf(ref byte[] src, int pad)
            {
                int len = (src.Length + pad - 1) / pad * pad;
                Array.Resize(ref src, len);
            }
    
            public static byte[] ConvertHexStringToByteArray(string hexString)
            {
                if (hexString.Length % 2 != 0)
                {
                    throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
                }
    
                byte[] HexAsBytes = new byte[hexString.Length / 2];
                for (int index = 0; index < HexAsBytes.Length; index++)
                {
                    string byteValue = hexString.Substring(index * 2, 2);
                    HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }
    
                return HexAsBytes;
            }
        }
    }
