	/*
	 * Encryption/Decryption, based on AES256 and PBKDF2
	 */
	public string Encrypt (string plainText, string passPhrase, bool fast_encrypt = false)
	{
		string result;
		using (Rijndael algR = Rijndael.Create ()) {
			RNGCryptoServiceProvider rngC = new RNGCryptoServiceProvider ();
			byte[] iv = new byte[16];
			rngC.GetBytes (iv);
			Rfc2898DeriveBytes derived = new Rfc2898DeriveBytes (passPhrase, iv, fast_encrypt ? 10 : 3000);
			algR.KeySize = 256;
			algR.BlockSize = 128;
			algR.Key = derived.GetBytes (32);
			algR.IV = iv;
			using (MemoryStream memoryStream = new MemoryStream ()) {
				memoryStream.Write (iv, 0, 16);
				using (CryptoStream cryptoStreamEncrypt = new CryptoStream (memoryStream, algR.CreateEncryptor (algR.Key, algR.IV), CryptoStreamMode.Write)) {
					using (StreamWriter streamWriterEncrypt = new StreamWriter (cryptoStreamEncrypt)) {
						streamWriterEncrypt.Write (plainText);
					}
				}
				result = Convert.ToBase64String (memoryStream.ToArray ());
			}
		}
		return result;
	}
	public string Decrypt (string cipherText, string passPhrase, bool fast_decrypt = false)
	{
		string result;
		using (Rijndael algR = Rijndael.Create ()) {
			using (MemoryStream memoryStream = new MemoryStream (Convert.FromBase64String (cipherText))) {
				byte[] iv = new byte[16];
				memoryStream.Read (iv, 0, 16);
				Rfc2898DeriveBytes derived = new Rfc2898DeriveBytes (passPhrase, iv, fast_decrypt ? 10 : 3000);
				algR.KeySize = 256;
				algR.BlockSize = 128;
				algR.Key = derived.GetBytes (32);
				algR.IV = iv;
				using (CryptoStream cryptoStreamDecrypt = new CryptoStream (memoryStream, algR.CreateDecryptor (algR.Key, algR.IV), CryptoStreamMode.Read)) {
					using (StreamReader streamReaderDecrypt = new StreamReader (cryptoStreamDecrypt)) {
						result = streamReaderDecrypt.ReadToEnd ();
					}
				}
			}
		}
		return result;
	}
