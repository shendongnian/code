	string ClearTextPromoCode = TextBox1.Text;
	byte[] ClearTextByteArray = System.Text.Encoding.UTF8.GetBytes(ClearTextPromoCode);
	System.Security.Cryptography.SHA1 SHA1Encryptor = new System.Security.Cryptography.SHA1CryptoServiceProvider();
	byte[] EncryptedByteArray = SHA1Encryptor.ComputeHash(ClearTextByteArray);
	string EncryptedPromoCode = System.Text.Encoding.UTF8.GetString(EncryptedByteArray);
