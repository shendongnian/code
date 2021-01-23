		public string DecryptData(string encryptedMessage, string password)
		{
			if (encryptedMessage.Length % 2 == 1)
				throw new Exception("The binary key cannot have an odd number of digits");
			byte[] byteArr = new byte[encryptedMessage.Length / 2];
			for (int index = 0; index < byteArr.Length; index++)
			{
				string byteValue = encryptedMessage.Substring(index * 2, 2);
				byteArr[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			byte[] result = Rijndael.DecryptData(
				byteArr,
				Encoding.ASCII.GetBytes(password),
				new byte[] { }, // Initialization vector
				Rijndael.BlockSize.Block256, // Typically 128 in most implementations
				Rijndael.KeySize.Key256,
				Rijndael.EncryptionMode.ModeEBC // Rijndael.EncryptionMode.ModeCBC
			);
			return ASCIIEncoding.ASCII.GetString(result);
		}
