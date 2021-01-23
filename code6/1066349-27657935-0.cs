     private static void AES_Encrypt(string inputFile, string outputFile, byte[] passwordBytes)
     {
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8};
            string cryptFile = outputFile;
            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.Zeros;
            AES.Mode = CipherMode.CBC;
            CryptoStream cs = new CryptoStream(fsCrypt,
                 AES.CreateEncryptor(),
                CryptoStreamMode.Write);
            FileStream fsIn = new FileStream(inputFile, FileMode.Open);
            int data;
            while ((data = fsIn.ReadByte()) != -1)
                cs.WriteByte((byte)data);
            fsIn.Close();
            cs.Close();
            fsCrypt.Close();
        }
        private static void AES_Decrypt(string inputFile, string outputFile, byte[] passwordBytes)
        {
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8};
            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.Zeros;
            AES.Mode = CipherMode.CBC;
            CryptoStream cs = new CryptoStream(fsCrypt,
                AES.CreateDecryptor(),
                CryptoStreamMode.Read);
            FileStream fsOut = new FileStream(outputFile, FileMode.Create);
            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);
            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
        }
    }
