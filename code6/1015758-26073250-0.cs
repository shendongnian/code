    static string Encrypt2(string publicKeyFileName, string inputMessage)
	{  
		try
		{
			// Converting the string message to byte array
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			byte[] inputBytes = enc.GetBytes(inputMessage);
			
			AsymmetricKeyParameter publicKey = ReadAsymmetricKeyParameter(publicKeyFileName);
			
			// Creating the RSA algorithm object
			IAsymmetricBlockCipher cipher =  new Pkcs1Encoding(new RsaEngine());
			
			// Initializing the RSA object for Encryption with RSA public key. Remember, for encryption, public key is needed
			cipher.Init(true, publicKey);
			
			//Encrypting the input bytes
			byte[] cipheredBytes = cipher.ProcessBlock(inputBytes, 0, inputBytes.Length);
			
			return Convert.ToBase64String(cipheredBytes);
		}
		catch (Exception ex)
		{
			// Any errors? Show them
			Debug.Log("Exception encrypting file! More info:");
			Debug.Log(ex.Message);
		}
		return "";
        
    }
	public static AsymmetricKeyParameter ReadAsymmetricKeyParameter(string pemFilename)
	{
		var fileStream = System.IO.File.OpenText(pemFilename);
		var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(fileStream);
		var KeyParameter = (Org.BouncyCastle.Crypto.AsymmetricKeyParameter)pemReader.ReadObject();
		return KeyParameter;
    }
