    using System;
    using System.Security.Cryptography;
    using System.IO;
    
    namespace YourNameSpace
    
    {
        public class EncryptDecrypt
        {
            #region Declaration
    
            static readonly byte[] TripleDesKey1 = new byte[] { 15, 11, 7, 21, 34, 32, 33, 5, 23, 13, 23, 41, 43, 41, 7, 19, 91, 91, 47, 7, 37, 13, 19, 41 };
            static readonly byte[] TripleDesiv1 = new byte[] { 5, 23, 13, 23, 41, 43, 41, 7 };
    
            #endregion
    
    
            /// <summary>
            /// To Encrypt String
            /// </summary>
            /// <param name="value">String To Encrypt</param>
            /// <returns>Returns Encrypted String</returns>
            public static string ToEncrypt(string value)
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider
                                                         {
                                                             Key = TripleDesKey1,
                                                             IV = TripleDesiv1
                                                         };
    
                MemoryStream ms;
    
                if (value.Length >= 1)
                    ms = new MemoryStream(((value.Length * 2) - 1));
                else
                    ms = new MemoryStream();
    
                ms.Position = 0;
                CryptoStream encStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(value);
                encStream.Write(plainBytes, 0, plainBytes.Length);
                encStream.FlushFinalBlock();
                encStream.Close();
    
                return Convert.ToBase64String(plainBytes);
            }
    
            /// <summary>
            /// To Decrypt Data Encrypted From TripleDEC Algoritham
            /// </summary>
            /// <param name="value">String Value To Decrypt</param>
            /// <returns>Return Decrypted Data</returns>
            public static string ToDecrypt(string value)
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(((value.Length * 2) - 1));
                MemoryStream ms;
                if (value.Length >= 1)
                    ms = new MemoryStream(((value.Length * 2) - 1));
                else
                    ms = new MemoryStream();
    
                ms.Position = 0;
                CryptoStream encStream = new CryptoStream(ms, des.CreateDecryptor(TripleDesKey1, TripleDesiv1), CryptoStreamMode.Write);
                byte[] plainBytes = Convert.FromBase64String(value);
                encStream.Write(plainBytes, 0, plainBytes.Length);
                return System.Text.Encoding.UTF8.GetString(plainBytes);
            }
    
        }
    }
