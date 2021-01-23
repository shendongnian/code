       public byte[] EncryptFile(Stream input, string password, string salt)
                {
        
                    // Essentially, if you want to use RijndaelManaged as AES you need to make sure that:
                    // 1.The block size is set to 128 bits
                    // 2.You are not using CFB mode, or if you are the feedback size is also 128 bits
        
                    var algorithm = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
                    var key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(salt));
        
                    algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
                    algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);
                    algorithm.Padding = PaddingMode.Zeros;
        
                    using (Stream cryptoStream = new MemoryStream())
                    using (var encryptedStream = new CryptoStream(cryptoStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        CopyStream(input, encryptedStream);
        
                        return ReadToEnd(cryptoStream);
                    }
                }
        
                public byte[] DecryptFile(Stream input, Stream output, string password, string salt)
                {
                    // Essentially, if you want to use RijndaelManaged as AES you need to make sure that:
                    // 1.The block size is set to 128 bits
                    // 2.You are not using CFB mode, or if you are the feedback size is also 128 bits
                    var algorithm = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
                    var key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(salt));
        
                    algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
                    algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);
                    algorithm.Padding = PaddingMode.Zeros;
        
                    try
                    {
                        using (var decryptedStream = new CryptoStream(output, algorithm.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            CopyStream(input, decryptedStream);
                            return ReadToEnd(output);
                        }
                    }
                    catch (CryptographicException ex)
                    {
                        throw new InvalidDataException("Please supply a correct password");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
