    public static byte[] EncryptDataAES(byte[] toEncrypt, byte[] key)
		{
			byte[] encryptedData;
            byte[] iv = { (byte) 0x00, (byte) 0x00, (byte) 0x00, (byte) 0x00,
                                                            (byte) 0x00, (byte) 0x00, (byte) 0x00, (byte) 0x00,
                                                            (byte) 0x00, (byte) 0x00, (byte) 0x00, (byte) 0x00,
                                                            (byte) 0x00, (byte) 0x00, (byte) 0x00, (byte) 0x00 };
			using (SymmetricAlgorithm aes = SymmetricAlgorithm.Create())
			{
				aes.Mode = CipherMode.CBC;
				aes.Key = key;
                aes.IV = iv;
				aes.Padding = PaddingMode.PKCS7;
				ICryptoTransform encryptor = aes.CreateEncryptor();
				using (MemoryStream mStream = new MemoryStream())
				{
					using (CryptoStream cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
					{
						cStream.Write(toEncrypt, 0, toEncrypt.Length);
						cStream.FlushFinalBlock();
						encryptedData = mStream.ToArray();
					}
				}
			}
			return encryptedData;
		}
