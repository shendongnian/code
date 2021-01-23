    public class TFRSAEncryption
	{
		public string RsaEncryptWithPublic(string clearText, string publicKey)
		{
			var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);
			var encryptEngine = new Pkcs1Encoding(new RsaEngine());
			using (var txtreader = new StringReader(publicKey))
			{
				var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();
				encryptEngine.Init(true, keyParameter);
			}
			var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
			return encrypted;
		}
		public string RsaEncryptWithPrivate(string clearText, string privateKey)
		{
			var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);
			var encryptEngine = new Pkcs1Encoding(new RsaEngine());
			using (var txtreader = new StringReader(privateKey))
			{
				var keyPair = (AsymmetricCipherKeyPair)new PemReader(txtreader).ReadObject();
				encryptEngine.Init(true, keyPair.Private);
			}
			var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
			return encrypted;
		}
		// Decryption:
		public string RsaDecryptWithPrivate(string base64Input, string privateKey)
		{
			var bytesToDecrypt = Convert.FromBase64String(base64Input);
			AsymmetricCipherKeyPair keyPair;
			var decryptEngine = new Pkcs1Encoding(new RsaEngine());
			using (var txtreader = new StringReader(privateKey))
			{
				keyPair = (AsymmetricCipherKeyPair)new PemReader(txtreader).ReadObject();
				decryptEngine.Init(false, keyPair.Private);
			}
			var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
			return decrypted;
		}
		public string RsaDecryptWithPublic(string base64Input, string publicKey)
		{
			var bytesToDecrypt = Convert.FromBase64String(base64Input);
			var decryptEngine = new Pkcs1Encoding(new RsaEngine());
			using (var txtreader = new StringReader(publicKey))
			{
				var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();
				decryptEngine.Init(false, keyParameter);
			}
			var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
			return decrypted;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			// Set up 
			var input = "Perceived determine departure explained no forfeited";
			var enc = new TFRSAEncryption();
			var publicKey = "-----BEGIN PUBLIC KEY----- // Base64 string omitted // -----END PUBLIC KEY-----";
            var privateKey = "-----BEGIN PRIVATE KEY----- // Base64 string omitted// -----END PRIVATE KEY-----";
			// Encrypt it
			var encryptedWithPublic = enc.RsaEncryptWithPublic(input, publicKey);
			var encryptedWithPrivate = enc.RsaEncryptWithPrivate(input, privateKey);
			// Decrypt
			var output1 = enc.RsaDecryptWithPrivate(encryptedWithPublic, privateKey);
			var output2 = enc.RsaDecryptWithPublic(encryptedWithPrivate, publicKey);
			Console.WriteLine(output1 == output2 && output2 == input);
			Console.Read();
		}
	}
