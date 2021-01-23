            using (Stream readStream = File.OpenRead(path))
            {
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                using (CryptoStream crStream = 
                    new CryptoStream(readStream, cryptic.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] data = ASCIIEncoding.ASCII.GetBytes(readStream.ToString());
                    crStream.Read(data, 0, data.Length);
                    BinaryFormatter formatter = new BinaryFormatter();
                    object obj = formatter.Deserialize(crStream);                    
                }
            }
