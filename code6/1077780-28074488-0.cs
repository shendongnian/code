    public static string RSAEncryption(string aes_key, string aes_iv)
        {
            //encode key and iv to byte array
            byte[] KeyToEncrypt = Encoding.Default.GetBytes(aes_key);
            byte[] IVToEncrypt = Encoding.Default.GetBytes(aes_iv);
            //get RSA public key from xml file
            TextReader reader = new StreamReader("publicKey.xml");
            string publicKey = reader.ReadToEnd();
            reader.Close();
            MessageBox.Show(publicKey);
            //Values to store encrypted symmetric keys.
            byte[] EncryptedKey;
            byte[] EncryptedIV;
            //Create a new instance of RSACryptoServiceProvider.
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            //set xml string as public key
            RSA.FromXmlString(publicKey);
            //Encrypt the symmetric key and IV.
            EncryptedKey = RSA.Encrypt(KeyToEncrypt, false);
            EncryptedIV = RSA.Encrypt(IVToEncrypt, false);
            System.IO.File.WriteAllText(@"C:\WriteTextCryptKey.txt", Convert.ToBase64String(EncryptedKey));
            System.IO.File.WriteAllText(@"C:\WriteTextCryptIV.txt", Convert.ToBase64String(EncryptedIV));
            return Convert.ToBase64String(EncryptedKey);
        }
