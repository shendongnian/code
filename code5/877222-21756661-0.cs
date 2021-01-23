	// create a RSA provider with a 1024 bits key
	using(RSACryptoServiceProvider rsaProv = new RSACryptoServiceProvider(1024))
	{
		// export public key and send it to server to obtain base64 token
		string publicKeyXml = rsaProv.ToXmlString(false);
		string base64TokenFromServer = GetTokenFromServer(publicKeyXml);
		// decode base64 token
		byte[] tokenBytes = Convert.FromBase64String(base64TokenFromServer);
		// sign token bytes using RSA provider's private key and SHA1
		byte[] tokenSignatureBytes;
		using (var ms = new MemoryStream(tokenBytes))
		{
			tokenSignatureBytes = rsaProv.SignData(ms, SHA1.Create());
		}
		// concat token bytes and signature bytes
		byte[] finalOut;
		using (var ms = new MemoryStream())
		{
			ms.Write(tokenBytes, 0, tokenBytes.Length);
			ms.Write(tokenSignatureBytes, 0, tokenSignatureBytes.Length);
			ms.Flush();
			finalOut = ms.ToArray();
		}
		// encode final out to base64
		string signedToken = Convert.ToBase64String(finalOut);
	}
