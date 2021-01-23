    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace EncryptionClient
    {
        class CryptoMaster
        {
            private string encryptedText;
    
            public void StartEncryption()
            {
                Console.WriteLine("");
                Console.WriteLine("----- Client Start -----");
                string plainText = "Hello, this is a message we need to encrypt";
                Console.WriteLine("Plain Text = " + plainText);
                string passPhrase ="Pass Phrase Can be any length";
                string saltValue = DateTime.Now.ToLongTimeString(); //slat should be 8 bite len, in my case im using Time HH:MM:SS as it is dynamic value
                string hashAlgorithm = "SHA1";
                int passwordIterations = 1;
                string initVector = "InitVector Should be 32 bite len";
                int keySize = 256;
                
                encryptedText = Encrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
                Console.WriteLine("Encrypted Text = " + encryptedText);
    
                string decryptedText = Decrypt(encryptedText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
                Console.WriteLine("Decripted Text = " + decryptedText);
                Console.WriteLine("----- Client End -----");
    
                SendDataToWebServer(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
            }
    
            private void SendDataToWebServer(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
            {
                
                NameValueCollection POST = new NameValueCollection();
                //NOTE: I'm Including all this data to POST only for TESTING PURPOSE 
                //and to avoid manual entering of the same data at server side.
                //In real live example you have to keep sensative data hidden
                POST.Add("plainText", plainText);
                POST.Add("passPhrase", passPhrase);
                POST.Add("saltValue", saltValue);
                POST.Add("hashAlgorithm", hashAlgorithm);
                POST.Add("passwordIterations", passwordIterations+"");
                POST.Add("initVector", initVector);
                POST.Add("keySize", keySize+"");
                POST.Add("encryptedText", encryptedText);
    
    
                WebClient web = new WebClient();
                string URL = "http://localhost/Encryptor.php";
                Console.WriteLine("");
                string serverRespond = Encoding.UTF8.GetString(web.UploadValues(URL, "POST", POST));
                Console.WriteLine("----- Server Start -----");
                Console.WriteLine(serverRespond);
                Console.WriteLine("----- Server End -----");
    
            }
    
            public string Encrypt(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
            {
    
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
    
                Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations);
    
                byte[] keyBytes = password.GetBytes(keySize / 8);
    
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.BlockSize = 256;
                symmetricKey.KeySize = 256;
                symmetricKey.Padding = PaddingMode.Zeros;
                symmetricKey.Mode = CipherMode.CBC;
    
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
    
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
    
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
    
                memoryStream.Close();
                cryptoStream.Close();
    
                string cipherText = Convert.ToBase64String(cipherTextBytes);
    
                return cipherText;
            }
    
            public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
            {
    
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
    
                Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations);
    
                byte[] keyBytes = password.GetBytes(keySize / 8);
    
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.BlockSize = 256;
                symmetricKey.KeySize = 256;
                symmetricKey.Padding = PaddingMode.Zeros;
                symmetricKey.Mode = CipherMode.CBC;
    
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
    
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
    
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
    
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
    
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
    
                memoryStream.Close();
                cryptoStream.Close();
    
                string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
     
                return plainText;
            }
        }
    }
