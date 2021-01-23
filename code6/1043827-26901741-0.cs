        public static byte[] decryptStream(byte[] encrypted, byte[] Key, byte[] IV)
        {
            byte[] plain;
            byte[] buffer = new byte[32768];
            int totalRead = 0;
            MemoryStream plainStream = new MemoryStream();
            using (MemoryStream mStream = new MemoryStream(encrypted))
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(mStream,
                        aesProvider.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    {
                        while (true)
                        {
                            int read = cryptoStream.Read(buffer, 0, encrypted.Length);
                            if (read == 0)
                                break;
                            else
                                plainStream.Write(buffer, totalRead, read);
                            totalRead += read;
                        }
                    }
                }
                plain = plainStream.ToArray();
            }
            return plain;
        }
