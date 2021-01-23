    protected void Page_Load(object sender, EventArgs e)
            {
                    Crypto crp = new Crypto("MyDifficultPassw");
                    string asd = crp.DecryptFromBase64("2xrT+9gHAw4Nh9H57kluwQ==");
            }
    
            public class Crypto
            {
                private ICryptoTransform rijndaelDecryptor;
                // Replace me with a 16-byte key, share between Java and C#
                private static byte[] rawSecretKey = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                                  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
    
                public Crypto(string passphrase)
                {
                    byte[] passwordKey = encodeDigest(passphrase);
                    RijndaelManaged rijndael = new RijndaelManaged();
                    rijndaelDecryptor = rijndael.CreateDecryptor(passwordKey, rawSecretKey);
                }
    
                public string Decrypt(byte[] encryptedData)
                {
                    byte[] newClearData = rijndaelDecryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                    return Encoding.ASCII.GetString(newClearData);
                }
    
                public string DecryptFromBase64(string encryptedBase64)
                {
                    return Decrypt(Convert.FromBase64String(encryptedBase64));
                }
    
                private byte[] encodeDigest(string text)
                {
                    MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    byte[] data = Encoding.ASCII.GetBytes(text);
                    return x.ComputeHash(data);
                }
            }
    
            static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key
    , byte[] IV)
            {
                // Check arguments. 
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
    
                // Declare the string used to hold 
                // the decrypted text. 
                string plaintext = null;
    
                // Create an Aes object 
                // with the specified key and IV. 
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    aesAlg.Padding = PaddingMode.None;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key
    , aesAlg.IV);
    
    
    
                    // Create the streams used for decryption. 
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
    
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt
    , decryptor, CryptoStreamMode.Read))
                        {
    
                            using (StreamReader srDecrypt = new StreamReader(
    csDecrypt))
                            {
    
                                // Read the decrypted bytes from the decrypting 
    
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
    
                }
    
                return plaintext;
    
            }
