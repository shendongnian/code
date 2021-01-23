    	static void test()
		{
			Console.WriteLine(Convert.ToBase64String(EncryptStringToBytes("this is a test", System.Text.Encoding.ASCII.GetBytes("abcdefghijklmnop"))));
		}
		static byte[] EncryptStringToBytes(string plainText, byte[] key)
		{
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (key == null || key.Length <= 0)
				throw new ArgumentNullException("key");
			byte[] encrypted;
			using (var rijAlg = new RijndaelManaged())
			{
				rijAlg.BlockSize = 256;
				rijAlg.Key = key;
				rijAlg.Mode = CipherMode.ECB;
				rijAlg.Padding = PaddingMode.Zeros;
				rijAlg.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
				ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
				using (var msEncrypt = new MemoryStream())
				using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (var swEncrypt = new StreamWriter(csEncrypt))
						swEncrypt.Write(plainText);
					encrypted = msEncrypt.ToArray();
				}
			}
			return encrypted;
		}
