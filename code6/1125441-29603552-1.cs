            string path = "D:\\changeit.txt";
            Object p = new Object();
            using (Stream stream = File.Create(path))
            {           
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                using (CryptoStream crStream = new
                      CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] data = ASCIIEncoding.ASCII.GetBytes(stream.ToString());
                    crStream.Write(data, 0, data.Length);
                    BinaryFormatter seri = new BinaryFormatter();
                    seri.Serialize(crStream, p);
                }
            }
