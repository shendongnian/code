	public static byte[] Decrypt3(byte[] data, string pemFilename)
	{
		try {
			AsymmetricKeyParameter key = readPrivateKey(pemFilename);
			
			RsaEngine e = new RsaEngine();
			
			e.Init(false, key);
			
			byte[] cipheredBytes = e.ProcessBlock(data, 0, data.Length);
			return cipheredBytes;
			
		} catch (Exception e) {
			Debug.Log ("Exception in Decrypt3: " + e.Message);
			return GetBytes(e.Message);
		}
	}
